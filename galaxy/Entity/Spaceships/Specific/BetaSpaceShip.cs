using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using galaxy.Entity.Spaceships.Engine;
using galaxy.Interface;

namespace galaxy.Entity.Spaceships
{
    public class BetaSpaceShip : SpaceShip
    {

        public BetaSpaceShip(Space space) : base(space)
        {
            vision = 50;
            status = SpaceShipStatus.Extraction;

            for (int i = 0; i < 3; i++)
            {
                engines.Add(EngineFactory.GetRandomEngine(space.random));
            }

            movement = space.random.Next() % 2 == 0 ? new MovementWithDiagonals() : new MovementWithoutDiagonals();
        }
    }
}
