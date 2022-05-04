using Hsc.World.TerrainGenerator.Enums;
using Hsc.World.TerrainGenerator.Interfaces.World.Generation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hsc.World.TerrainGenerator.Core.Model
{
    public class TileGroupDefinition : ITileGroupDefinition<TileDefinition>
    {
        public Dictionary<string, TileDefinition> TileDefinitions { get; set; }
        public Dictionary<Direction, HashSet<string>> AdjacencyGroups { get; set; } = new Dictionary<Direction, HashSet<string>>();
        public TileDefinitionSpawnType SpawnType { get; set; } = TileDefinitionSpawnType.Initial;
    }
}
