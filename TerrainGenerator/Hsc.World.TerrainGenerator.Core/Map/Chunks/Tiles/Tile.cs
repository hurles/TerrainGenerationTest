using Hsc.World.TerrainGenerator.Interfaces.World.Chunks.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hsc.World.TerrainGenerator.Core.Map.Chunks.Tiles
{
    public class Tile : ITile
    {
        public long TileTypeId { get; set; }

    }
}
