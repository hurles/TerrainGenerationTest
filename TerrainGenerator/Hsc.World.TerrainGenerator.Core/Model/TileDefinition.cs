using Hsc.World.TerrainGenerator.Enums;
using Hsc.World.TerrainGenerator.Interfaces.World.Generation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hsc.World.TerrainGenerator.Core.Model
{
    public class TileDefinition : ITileDefinition
    {
        public string Identifier { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
    }
}
