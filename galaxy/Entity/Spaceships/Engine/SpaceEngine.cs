using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxy.Entity.Spaceships.Engine
{
    public abstract class SpaceEngine
    {
        protected int maxCapacity;
        protected int currentCapacity;

        const int valueOfMovement = 10;

        protected SpaceEngine(int maxCapacity, int currentCapacity) {
            this.maxCapacity = maxCapacity;
            this.currentCapacity = currentCapacity;
        }

        protected bool makeMove()
        {
            if (currentCapacity - valueOfMovement < 0)
            {
                return false;
            }
            else
            {
                currentCapacity -= valueOfMovement;
                return true;
            }
        }

        protected bool makeRefueling(int fuelQuantity)
        {
            if (currentCapacity + fuelQuantity > maxCapacity)
            {
                currentCapacity = maxCapacity;
                return false;
            }
            else
            {
                currentCapacity += fuelQuantity;
                return true;
            }
        }
    }
}
