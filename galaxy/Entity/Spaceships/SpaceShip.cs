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
        protected SpaceShipStatus status;
        
        public SpaceShip(Space space) : base(space) 
        {
            engines= new List<SpaceEngine>();
        }

        public virtual void play(Random random)
        {


            if status == SpaceShipStatus.Die {
                return
            } else if status == SpaceShipStatus.inSearch {
                movement.GetNextCoordinate(coordinate, vision, random);
            } else if status == SpaceShipStatus.justFloatin {
                movement.GetNextCoordinate(coordinate, vision, random)
            }


        }
    }
}
