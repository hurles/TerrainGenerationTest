using Hsc.World.TerrainGenerator.Core.Map;
using Hsc.World.TerrainGenerator.Core.Map.Chunks;
using Hsc.World.TerrainGenerator.Core.Map.Chunks.Tiles;
using Hsc.World.TerrainGenerator.Core.Model;
using Hsc.World.TerrainGenerator.Core.Model.ModelLoader;
using Hsc.World.TerrainGenerator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hsc.World.TerrainGenerator.Core.Generation
{
    public class TerrainGenerator
    {
        private WorldDefinition _worldDefinition;
        private WorldHelper _worldHelper;

        private Terrain _world;

        public TerrainGenerator(WorldDefinition worldDefinition, WorldHelper worldHelper)
        {
            _world = new Terrain("TestWorld");
            _worldDefinition = worldDefinition;
            _worldHelper = worldHelper;
            _worldHelper.LoadDefinitions(_worldDefinition);
        }

        public async Task<Chunk> GenerateChunkAsync(long startX, long startY, long startZ, CancellationToken cancellationToken = default)
        {
            var chunk = new Chunk();
            var rnd = new Random();

            var initialPossibilities = _worldHelper.GetInitialSpawnableTileGroups().ToHashSet();

            Dictionary<(long, long), long> entropyMap = new();

            HashSet<(long x, long y)> spawnedTiles = new();


            while (spawnedTiles.Count < Chunk.ChunkSize * Chunk.ChunkSize)
            {
                var tileData = await GetLowestEntropy(startX, startY, initialPossibilities, entropyMap, spawnedTiles);


                    if (!chunk.Tiles.ContainsKey(tileData.Position.x))
                        chunk.Tiles.Add(tileData.Position.x, new Dictionary<long, Tile>());

                    chunk.Tiles[tileData.Position.x].Add(tileData.Position.y, new Tile() { TileTypeId = tileData.Possibilities.ElementAt(rnd.Next(tileData.PossibilitiesCount)) });

                spawnedTiles.Add(tileData.Position);
            }

            return chunk;
        }

        private class EntropyResult
        {
            public EntropyResultType Type { get; set; } = EntropyResultType.Constrained;
            public (long x, long y) Position { get; set; }
            public HashSet<long> Possibilities { get; set; }
            public int PossibilitiesCount { get; set; }
        }

        private enum EntropyResultType
        {
            Full,
            Constrained
        }


        private async Task<EntropyResult> GetLowestEntropy(long startX, long startY, HashSet<long> initialPossibilities, Dictionary<(long, long), long> entropyMap, HashSet<(long, long)> spawnedTiles)
        {
            Random random = new Random();
            long lowestEntropy = -1;
            List<(long, long)> tilesWithLowestEntropy = new();
            Dictionary<(long, long), HashSet<long>> possibilitiesDict = new();

            var output = new EntropyResult();

            for (long y = 0; y < Chunk.ChunkSize; y++)
            {
                for (long x = 0; x < Chunk.ChunkSize; x++)
                {
                    if (spawnedTiles.Contains((x, y)))
                        continue;

                    HashSet<long> possibilities = new HashSet<long>();

                    var worldX = startX + x;
                    var worldY = startY + y;


                    var northTile = await GetTileAsync(worldX, worldY - 1);
                    var southTile = await GetTileAsync(worldX, worldY + 1);
                    var westTile = await GetTileAsync(worldX - 1, worldY);
                    var eastTile = await GetTileAsync(worldX + 1, worldY);


                    possibilities = CheckAdjecentTile(northTile, Direction.South, possibilities);
                    possibilities = CheckAdjecentTile(southTile, Direction.North, possibilities);
                    possibilities = CheckAdjecentTile(westTile, Direction.East, possibilities);
                    possibilities = CheckAdjecentTile(eastTile, Direction.West, possibilities);

                    if (!possibilities.Any())
                        possibilities = new HashSet<long>(initialPossibilities);

                    if (!entropyMap.ContainsKey((x, y)))
                        entropyMap.Add((x, y), possibilities.Count);

                    if (lowestEntropy == -1 || (lowestEntropy > possibilities.Count))
                    {
                        lowestEntropy = possibilities.Count;
                        tilesWithLowestEntropy.Clear();
                        possibilitiesDict.Clear();
                    }

                    if (possibilities.Count == lowestEntropy)
                    {
                        tilesWithLowestEntropy.Add((x, y));

                        possibilitiesDict.Add((x, y), possibilities);
                    }
                }
            }

            var tilePos = tilesWithLowestEntropy[random.Next(tilesWithLowestEntropy.Count)];
            var possibleTypes = possibilitiesDict[tilePos];
            output.Position = tilePos;
            output.Possibilities = possibleTypes;
            output.PossibilitiesCount = possibleTypes.Count;
            if (lowestEntropy == -1)
                output.Type = EntropyResultType.Full;
            return output;
        }

        private HashSet<long> CheckAdjecentTile(Tile? tile, Direction dir, HashSet<long> possibilities)
        {

            if (tile != null)
                possibilities.RemoveWhere(x => !_worldHelper.GetAdjecencyRulesForTileType(tile.TileTypeId, dir).Contains(x));

            return possibilities;
        }

        public async Task<Terrain> GenerateTerrainAsync()
        {

            var chunks = 8;
            var chunkGridSize = 32;

            for (long y = 0; y < (chunkGridSize * chunks); y += chunkGridSize)
            {
                for (long x = 0; x < (chunkGridSize * chunks); x += chunkGridSize)
                {
                    if (!_world.Chunks.ContainsKey(x))
                        _world.Chunks.Add(x, new Dictionary<long, Chunk>());

                    _world.Chunks[x].Add(y, await GenerateChunkAsync(x, y, 0));
                }
            }

            return _world;
        }

        public async Task<Tile?> GetTileAsync(long xPos, long yPos)
        {

            var chunkXPos = xPos - (xPos % Chunk.ChunkSize);
            var chunkYPos = yPos - (yPos % Chunk.ChunkSize);
            var tilePosX = xPos - chunkXPos;
            var tilePosY = yPos - chunkYPos;


            if (_world.Chunks.ContainsKey(chunkXPos) && _world.Chunks[chunkXPos].TryGetValue(chunkYPos, out var chunk))
            {
                if (chunk.Tiles.ContainsKey(tilePosX) && chunk.Tiles[tilePosX].TryGetValue(tilePosY, out var tile))
                    return tile;
            }
            return null;

        }
    }
}
