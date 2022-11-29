using galaxy.Entity.Spaceships.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxy.Entity.Spaceships
{
    public class AlphaSpaceShip : SpaceShip
    {

        public AlphaSpaceShip(Space space) : base(space) {
            vision = 20;
            status = SpaceShipStatus.inSearch

            int maxCapacity = space.random.Next(700, 2000);
            int currentCapacity = Convert.ToInt32(maxCapacity * 0.6);

            engines.Add(new OilEngine(maxCapacity, currentCapacity));
            movement = ;
        }
    }
}
