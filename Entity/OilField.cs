using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxy.Entity
{
    public class OilField : GameEntity 
    {

        private int startCapacity;
        private int power;

        public OilField(Space space) : base (space)
        {
            startCapacity = space.random.Next(50, 300);
            power = space.random.Next(5, 40);
        }

        public int getFuel()
        {
            startCapacity -= power;
            if (startCapacity > 0)
            {
                return power;
            } else
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
