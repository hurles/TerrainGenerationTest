using Hsc.World.TerrainGenerator.Enums;
using Hsc.World.TerrainGenerator.Interfaces.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hsc.World.TerrainGenerator.Interfaces.World.Generation
{
    public interface ITileGroupDefinition<TTileDefinition> where TTileDefinition : ITileDefinition
    {
        public TileDefinitionSpawnType SpawnType { get; set; }

        public Dictionary<string, TTileDefinition> TileDefinitions { get; set; }

        public Dictionary<Direction, HashSet<string>> AdjacencyGroups { get; set; }

    }
}
