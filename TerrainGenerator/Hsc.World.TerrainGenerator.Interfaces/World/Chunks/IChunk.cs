using Hsc.World.TerrainGenerator.Enums;
using Hsc.World.TerrainGenerator.Interfaces.General;
using Hsc.World.TerrainGenerator.Interfaces.World.Chunks.Tiles;

namespace Hsc.World.TerrainGenerator.Interfaces.World.Chunks
{
    public interface IChunk<TTile> where TTile : ITile
    {
        public long PositionX { get; set; }
        public long PositionY { get; set; }
        public long PositionZ { get; set; }

        public Dictionary<long, Dictionary<long, TTile>> Tiles { get; set; }

    }
}
