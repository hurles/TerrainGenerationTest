using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Hsc.World.TerrainGenerator.Interfaces.General
{
    public interface IPositionable
    {
        public Vector3 Position { get; set; }
    }
}
