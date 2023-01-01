using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxy.Entity.Spaceships.Engine
{
    static class EngineFactory
    {
        public static SpaceEngine GetRandomEngine(Random random)
        {
            int maxCapacity = random.Next(2000, 5000);
            int currentCapacity = Convert.ToInt32(maxCapacity * 0.6);

            switch (random.Next(1,4)) {
                case 1:
                    return new OilEngine(maxCapacity, currentCapacity);
                case 2:
                    return new SolarEngine(maxCapacity, currentCapacity);
                default:
                    return new NuclearEngine(maxCapacity, currentCapacity);
            }
        }
    }
}
