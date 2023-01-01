using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxy.Entity
{
    public class SpaceStation: GameEntity
    {
        private int startCapacity;
        private int power;

        public SpaceStation(Space space) : base (space)
        {
            startCapacity = space.random.Next(70, 2000);
            power = space.random.Next(7, 60);
        }

        public int getFuel()
        {
            startCapacity -= power;
            if (startCapacity > 0)
            {
                return power;
            }
            else
            {
                Die();
                return 0;
            }
        }

        protected override void Die()
        {
            base.Die();
        }
    }
}
