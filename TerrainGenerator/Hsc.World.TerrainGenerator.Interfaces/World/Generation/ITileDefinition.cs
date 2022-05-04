﻿using Hsc.World.TerrainGenerator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hsc.World.TerrainGenerator.Interfaces.World.Generation
{
    public interface ITileDefinition
    {
        public string Identifier { get; set; }

        public string Name { get; set; }

    }
}
