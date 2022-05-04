using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hsc.World.TerrainGenerator.Interfaces.World.Generation
{
    public interface IWorldDefinition<TTileGroupDefinition, TTileDefinition> 
        where TTileGroupDefinition : ITileGroupDefinition<TTileDefinition> where TTileDefinition : ITileDefinition
    {
        public Dictionary<string, TTileGroupDefinition> TileGroups { get; set; }

    }
}
