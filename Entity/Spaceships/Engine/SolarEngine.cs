using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxy.Entity.Spaceships.Engine
{
    public class SolarEngine : SpaceEngine 
    {
        public SolarEngine(int maxCapacity, int currentCapacity) : base(maxCapacity, currentCapacity)
        {
            valueOfMovement = 10;
        }
    }
}
