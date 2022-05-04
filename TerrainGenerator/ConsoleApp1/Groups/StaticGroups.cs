using Hsc.World.TerrainGenerator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrainGeneratorTest.Groups
{
    public class StaticGroups
    {
        public static Dictionary<Direction, HashSet<string>> GrassAdjecency = new()
        {
            {
                Direction.Up,
                new()
                {
                    "Air"
                }
            },
            {
                Direction.North,
                new()
                {
                    "Grass",
                    "Sand"
                }
            },
            {
                Direction.East,
                new()
                {
                    "Grass",
                    "Sand"
                }
            },
            {
                Direction.South,
                new()
                {
                    "Grass",
                    "Sand"
                }
            },
            {
                Direction.West,
                new()
                {
                    "Grass",
                    "Sand"
                }
            },
            {
                Direction.Down,
                new()
                {
                    "Grass"
                }
            }

        };

        public static Dictionary<Direction, HashSet<string>> SandAdjecency = new()
        {
            {
                Direction.Up,
                new()
                {
                    "Air"
                }
            },
            {
                Direction.North,
                new()
                {
                    "Grass",
                    "Sand",
                    "Water"
                }
            },
            {
                Direction.East,
                new()
                {
                    "Grass",
                    "Sand",
                    "Water"
                }
            },
            {
                Direction.South,
                new()
                {
                    "Grass",
                    "Sand",
                    "Water"
                }
            },
            {
                Direction.West,
                new()
                {
                    "Grass",
                    "Sand",
                    "Water"
                }
            },
            {
                Direction.Down,
                new()
                {
                    "Grass",
                    "Sand",
                    "Water"
                }
            }

        };

        public static Dictionary<Direction, HashSet<string>> WaterAdjecency = new()
        {
            {
                Direction.Up,
                new()
                {
                    "Air"
                }
            },
            {
                Direction.North,
                new()
                {
                    "Sand",
                    "Water"
                }
            },
            {
                Direction.East,
                new()
                {
                    "Sand",
                    "Water"
                }
            },
            {
                Direction.South,
                new()
                {
                    "Sand",
                    "Water"
                }
            },
            {
                Direction.West,
                new()
                {
                    "Sand",
                    "Water"
                }
            },
            {
                Direction.Down,
                new()
                {
                    "Sand",
                    "Water"
                }
            }

        };


        public static Dictionary<Direction, HashSet<string>> AirAdjecency = new()
        {
            {
                Direction.Up,
                new()
                {
                    "Air"
                }
            },
            {
                Direction.North,
                new()
                {
                    "Air"
                }
            },
            {
                Direction.East,
                new()
                {
                    "Air"
                }
            },
            {
                Direction.South,
                new()
                {
                    "Air"
                }
            },
            {
                Direction.West,
                new()
                {
                    "Air"
                }
            },
            {
                Direction.Down,
                new()
                {
                    "Air"
                }
            }

        };
    }
}

