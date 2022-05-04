using Hsc.World.TerrainGenerator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hsc.World.TerrainGenerator.Core.Model.ModelLoader
{
    public class WorldHelper
    {
        Dictionary<long, TileGroupModel> _tileGroupModels = new();
        Dictionary<long, TileDefinition> _tileMappings = new();

        Dictionary<long, List<long>> _tileGroupMappings = new();
        List<long> _availableTileGroups = new();
        List<long> _initialSpawnableTileGroups = new();

        //various dictionaries to allow for faster getting of neighbouring rules
        // - sacrificing memory for speed
        Dictionary<long, HashSet<long>> _tileNorthAdjecencyMapping = new();
        Dictionary<long, HashSet<long>> _tileEastAdjecencyMapping = new();
        Dictionary<long, HashSet<long>> _tileSouthAdjecencyMapping = new();
        Dictionary<long, HashSet<long>> _tileWestAdjecencyMapping = new();
        Dictionary<long, HashSet<long>> _tileUpAdjecencyMapping = new();
        Dictionary<long, HashSet<long>> _tileDownAdjecencyMapping = new();

        public List<long> GetAvailableTileGroups()
        {
            return _availableTileGroups;
        }

        public List<long> GetInitialSpawnableTileGroups()
        {
            return _initialSpawnableTileGroups;
        }

        public TileGroupModel GetTileGroupDetails(long tileGroupId)
        {
            return _tileGroupModels[tileGroupId];
        }

        public HashSet<long> GetAdjecencyRulesForTileType(long tileId, Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return _tileNorthAdjecencyMapping[tileId];
                case Direction.East:
                    return _tileEastAdjecencyMapping[tileId];
                case Direction.South:
                    return _tileSouthAdjecencyMapping[tileId];
                case Direction.West:
                    return _tileWestAdjecencyMapping[tileId];
                case Direction.Up:
                    return _tileUpAdjecencyMapping[tileId];
                case Direction.Down:
                    return _tileDownAdjecencyMapping[tileId];
                default:
                    return new HashSet<long>();
            }
        }

        public void LoadDefinitions(WorldDefinition worldDefinition)
        {
            foreach (var item in worldDefinition.TileGroups)
            {
                var hash = GetHash(item.Key);
                _tileGroupModels.Add(hash, new TileGroupModel());
                _tileGroupMappings.Add(hash, new List<long>());
                _availableTileGroups.Add(hash);

                if (item.Value.SpawnType != TileDefinitionSpawnType.AfterNeighbor)
                    _initialSpawnableTileGroups.Add(hash);

                _tileNorthAdjecencyMapping.Add(hash, item.Value.AdjacencyGroups[Direction.North].Select(x => GetHash(x)).ToHashSet());
                _tileEastAdjecencyMapping.Add(hash, item.Value.AdjacencyGroups[Direction.East].Select(x => GetHash(x)).ToHashSet());
                _tileSouthAdjecencyMapping.Add(hash, item.Value.AdjacencyGroups[Direction.South].Select(x => GetHash(x)).ToHashSet());
                _tileWestAdjecencyMapping.Add(hash, item.Value.AdjacencyGroups[Direction.West].Select(x => GetHash(x)).ToHashSet());
                _tileUpAdjecencyMapping.Add(hash, item.Value.AdjacencyGroups[Direction.Up].Select(x => GetHash(x)).ToHashSet());
                _tileDownAdjecencyMapping.Add(hash, item.Value.AdjacencyGroups[Direction.Down].Select(x => GetHash(x)).ToHashSet());


                foreach (var tile in item.Value.TileDefinitions)
                {
                    var tileHash = GetHash(tile.Key);
                    _tileGroupModels[hash].TileIds.Add(tileHash);
                    _tileGroupMappings[hash].Add(tileHash);
                    _tileMappings.Add(tileHash, tile.Value);
                }
            }
        }

        public long GetHash(string value)
        {
            MD5 md5Hasher = MD5.Create();
            var hashed = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(value));
            return BitConverter.ToInt64(hashed, 0);
        }
        
        public TileDefinition GetTileDefinition(long tileId)
        {
            if (_tileMappings.ContainsKey(tileId))
            {
                var rnd = new Random();
                return _tileMappings[tileId];
            }

            return null!;
        }

        public long GetRandomTileFromGroup(long tileGroupId)
        {
            if (_tileGroupMappings.ContainsKey(tileGroupId))
            {
                var rnd = new Random();
                return _tileGroupMappings[tileGroupId][rnd.Next(_tileGroupMappings[tileGroupId].Count)];
            }

            return -1;
        }

        public long GetRandomTile()
        {
            var rnd = new Random();
            return GetRandomTileFromGroup(_availableTileGroups[rnd.Next(_availableTileGroups.Count)]);
        }
    }

    public class TileGroupModel
    {
        public HashSet<long> TileIds = new HashSet<long>();
    }

}
