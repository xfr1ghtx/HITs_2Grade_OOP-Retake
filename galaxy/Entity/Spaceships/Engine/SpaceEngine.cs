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
        protected int warningCapacity;

        protected int valueOfMovement;

        protected SpaceEngine(int maxCapacity, int currentCapacity) {
            this.maxCapacity = maxCapacity;
            this.warningCapacity = maxCapacity / 2;
            this.currentCapacity = currentCapacity;
        }

        public bool makeMove()
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

        public bool makeRefueling(int fuelQuantity)
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

        public int getCurrentCapacity() { return currentCapacity; }
        public int getWarningCapacity() { return warningCapacity; }
    }
}
