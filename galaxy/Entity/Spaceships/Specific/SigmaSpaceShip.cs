using galaxy.Entity.Spaceships.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxy.Entity.Spaceships
{
    public class SigmaSpaceShip : SpaceShip
    {
        public SigmaSpaceShip(Space space) : base(space) 
        {
            vision = 40;
            status = SpaceShipStatus.inSearch

            for (int i = 0; i < 3; i++)
            {
                int maxCapacity = space.random.Next(700, 2000);
                int currentCapacity = Convert.ToInt32(maxCapacity * 0.6);

                if ( i == 0)
                {
                    engines.Add(new OilEngine(maxCapacity, currentCapacity));
                }
                else if ( i == 1) 
                { 
                    engines.Add(new SolarEngine(maxCapacity, currentCapacity));
                }
                else if ( i == 2) 
                {
                    engines.Add(new NuclearEngine(maxCapacity, currentCapacity));
                }
            }

            movement = ;
         
        }
    }
}
