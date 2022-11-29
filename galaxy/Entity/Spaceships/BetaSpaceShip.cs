using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using galaxy.Entity.Spaceships.Engine;

namespace galaxy.Entity.Spaceships
{
    public class BetaSpaceShip : SpaceShip
    {

        public BetaSpaceShip(Space space) : base(space)
        {
            vision = 50;

            for (int i = 0; i < 3; i++)
            {
                engines.Add(EngineFactory.GetRandomEngine(space.random));
            }

            movement = ;
            

        }
    }
}
