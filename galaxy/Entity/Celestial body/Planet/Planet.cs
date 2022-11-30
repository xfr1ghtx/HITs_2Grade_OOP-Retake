using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxy.Entity.Celestial_body
{
    public class Planet : CelestialBody
    {
        public Planet (Space space) : base (space)
        {

            bodyRadius = space.random.Next(50, 100);
        }
    }
}
