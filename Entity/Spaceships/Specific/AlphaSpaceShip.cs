using galaxy.Entity.Spaceships.Engine;
using galaxy.Interface;
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
            status = SpaceShipStatus.Extraction;

            int maxCapacity = space.random.Next(2000, 5000);
            int currentCapacity = Convert.ToInt32(maxCapacity * 0.6);

            engines.Add(new OilEngine(maxCapacity, currentCapacity));
            movement = space.random.Next() % 2 == 0 ? new MovementWithDiagonals() : new MovementWithoutDiagonals();
        }
    }
}
