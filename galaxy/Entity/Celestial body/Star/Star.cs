using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxy.Entity.Celestial_body
{
    public class Star : CelestialBody
    {
        private int _deathRadius;
        private int _energyRadius;

        private int _power;

        private const int deathPersent = 20;
        private const int energyPersent = 40;

        public Star(Space space) : base(space) {
            bodyRadius = space.random.Next(5, 31);

            _deathRadius = bodyRadius * deathPersent / 100;
            _energyRadius = bodyRadius * energyPersent / 100;

            _power = space.random.Next(10, 50);

        }

        public int getDeathRadius() { return _deathRadius;}
        public int getEnergyRadius() { return _energyRadius;}
        public int getPower() { return _power;}
    }


}
