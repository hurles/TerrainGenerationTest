using Hsc.World.TerrainGenerator.Interfaces.World.Generation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hsc.World.TerrainGenerator.Core.Model
{
    public class WorldDefinition : IWorldDefinition<TileGroupDefinition, TileDefinition>
    {
        public Dictionary<string, TileGroupDefinition> TileGroups { get; set; } = new();
    }
}
