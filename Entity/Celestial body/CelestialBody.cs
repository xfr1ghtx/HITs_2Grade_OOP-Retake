using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxy.Entity
{
    abstract public class CelestialBody : GameEntity
    {
        protected int bodyRadius;

        public CelestialBody (Space space) : base (space)
        { 
        }

        public int getBodyRadius() { return bodyRadius; }
    }
}
