using Hsc.World.TerrainGenerator.Interfaces.General;
using Hsc.World.TerrainGenerator.Interfaces.World.Chunks;
using Hsc.World.TerrainGenerator.Interfaces.World.Chunks.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hsc.World.TerrainGenerator.Interfaces.World
{
    public interface IWorld<TChunk, TTile> : INameable
        where TTile : ITile
        where TChunk : IChunk<TTile>
    {
        public Dictionary<long, Dictionary<long, TChunk>> Chunks { get; set; }
    }
}
