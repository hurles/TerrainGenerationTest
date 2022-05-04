using Hsc.World.TerrainGenerator.Core.Map.Chunks;
using Hsc.World.TerrainGenerator.Core.Map.Chunks.Tiles;
using Hsc.World.TerrainGenerator.Interfaces.General;
using Hsc.World.TerrainGenerator.Interfaces.World;
using Hsc.World.TerrainGenerator.Interfaces.World.Chunks;
using Hsc.World.TerrainGenerator.Interfaces.World.Chunks.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hsc.World.TerrainGenerator.Core.Map
{
    public class Terrain : IWorld<Chunk, Tile>, INameable
    {
        public string Name { get; set; } = null!;

        public Dictionary<long, Dictionary<long, Chunk>> Chunks { get; set; } = new Dictionary<long, Dictionary<long, Chunk>>();

        public Terrain(string name)
        {
            Name = name;
        }
    }
}
