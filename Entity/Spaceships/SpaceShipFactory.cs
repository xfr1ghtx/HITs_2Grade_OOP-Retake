using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxy.Entity.Spaceships
{
    static class SpaceShipFactory
    {
        public static SpaceShip GetRandomSpaceShip(Space space, Random random)
        {
            switch (random.Next(1,5))
            {
                case 1:
                    return new AlphaSpaceShip(space);
                case 2:
                    return new BetaSpaceShip(space);
                case 3:
                    return new DeltaSpaceShip(space);
                default:
                    return new SigmaSpaceShip(space);
            }
        }
    }
}
