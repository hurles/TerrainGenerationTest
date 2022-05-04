using Hsc.World.TerrainGenerator.Core.Map.Chunks.Tiles;
using Hsc.World.TerrainGenerator.Interfaces.World.Chunks;
using Hsc.World.TerrainGenerator.Interfaces.World.Chunks.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Hsc.World.TerrainGenerator.Core.Map.Chunks
{
    public class Chunk : IChunk<Tile>
    {
        public const int ChunkSize = 32;
        public Dictionary<long, Dictionary<long, Tile>> Tiles { get; set; } = new();
        public long PositionX { get; set; }
        public long PositionY { get; set; }
        public long PositionZ { get; set; }
    }
}
