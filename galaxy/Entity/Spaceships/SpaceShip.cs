using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using galaxy.Entity.Spaceships.Engine;
using galaxy.Interface;

namespace galaxy.Entity.Spaceships
{
    public abstract class SpaceShip: GameEntity
    {
        protected int vision;
        protected List<SpaceEngine> engines;
        protected IMovement movement;
        
        public SpaceShip(Space space) : base(space) 
        {
            engines= new List<SpaceEngine>();
        }
    }
}
