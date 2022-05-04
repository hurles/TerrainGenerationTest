using Hsc.World.TerrainGenerator.Core.Model;
using Hsc.World.TerrainGenerator.Enums;
using Hsc.World.TerrainGenerator.Interfaces.World.Generation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrainGeneratorTest.Groups;

namespace TerrainGeneratorTest
{
    public class Definitions
    {
        public static WorldDefinition GetWorldDefinition() => new WorldDefinition()
        {
            TileGroups = new Dictionary<string, TileGroupDefinition>()
            {            
                {   
                    "Air", new TileGroupDefinition()
                        {
                            SpawnType = TileDefinitionSpawnType.AfterNeighbor,
                            AdjacencyGroups = StaticGroups.AirAdjecency,
                            TileDefinitions = new Dictionary<string, TileDefinition>()
                            {
                                { "Air_01", new() 
                                    { 
                                        Identifier = "Air_01",
                                        Name = "A",
                                    } 
                                }
                            }
                        }
                },                
                {
                    "Grass", new TileGroupDefinition()
                        {
                            AdjacencyGroups = StaticGroups.GrassAdjecency,
                            TileDefinitions = new Dictionary<string, TileDefinition>()
                            {
                                {
                                    "Grass_01", new()
                                    {
                                        Identifier = "Grass_01",
                                        Name = "G",
                                    }
                                },
                                {
                                    "Grass_02", new()
                                    {
                                        Identifier = "Grass_02",
                                        Name = "G",
                                    }
                                },
                                {
                                    "Grass_03", new()
                                    {
                                        Identifier = "Grass_02",
                                        Name = "G",
                                    }
                                }
                            }
                        }
                },
                {
                    "Sand", new TileGroupDefinition()
                        {
                            AdjacencyGroups = StaticGroups.SandAdjecency,
                            TileDefinitions = new Dictionary<string, TileDefinition>()
                            {
                                {
                                    "Sand_01", new()
                                    {
                                        Identifier = "Sand_01",
                                        Name = "."
                                    }
                                },
                                {
                                    "Sand_02", new()
                                    {
                                        Identifier = "Sand_02",
                                        Name = "."
                                    }
                                },
                                {
                                    "Sand_03", new()
                                    {
                                        Identifier = "Sand_03",
                                        Name = "."
                                    }
                                }
                            }
                        }
                },
                {
                    "Water", new TileGroupDefinition()
                        {
                            AdjacencyGroups = StaticGroups.WaterAdjecency,
                            TileDefinitions = new Dictionary<string, TileDefinition>()
                            {
                                {
                                    "Water_01", new()
                                    {
                                        Identifier = "Water_01",
                                        Name = "~",
                                    }
                                }
                            }
                        }
                }
            }
        };
    }
}
