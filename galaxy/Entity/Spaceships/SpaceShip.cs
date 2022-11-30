﻿using System;
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
        protected GameEntity target;
        protected List<SpaceEngine> engines;
        protected int oilStorage;
        protected int maxOilStorage;
        protected IMovement movement;
        protected SpaceShipStatus status;
        
        public SpaceShip(Space space) : base(space) 
        {
            engines= new List<SpaceEngine>();
            target = null;
            oilStorage = 0;
            maxOilStorage = space.random.Next(200,10000);
        }

        public virtual void Play(Random random)
        {
            if (target == null)
            {
                target = getPotentialTarget();
            } else
            {
                var coordinate = movement.Move(this.coordinate , target.coordinate);
                if (coordinate.X == 0 && coordinate.Y == 0)
                {
                    if (status == SpaceShipStatus.Fuel)
                    {
                        _space.Fuel(this);
                    } else if (status == SpaceShipStatus.Extraction) 
                    {
                        _space.StartExtraction(this);
                    }
                }
                else
                {
                    if (haveFuelForMove())
                    {
                        _space.DeleteSpaceship(this);
                        this.coordinate = new Coordinate(this.coordinate.X + coordinate.X, this.coordinate.Y + coordinate.Y);
                        _space.SetSpaceship(this);
                    }
                    else
                    {
                        Die();
                        _space.DeleteSpaceship(this);
                    }
                }
            }
        }

        public void ExtractionOil(int extraction)
        {
            if (oilStorage + extraction > maxOilStorage)
            {
                oilStorage = maxOilStorage;
                status = SpaceShipStatus.Chill;
            } else
            {
                oilStorage += extraction;
            }

        }

        private bool haveFuelForMove()
        {
            foreach (SpaceEngine engine in engines) {
                if (engine.makeMove())
                {
                    return true;
                }
            }
            return false;
        }

        public void DeleteTarget()
        {
            if (target != null )
            {
                target = null;
            }
        }

        public void NuclearFuel(int fuel)
        {
            foreach (var engine in engines)
            {
                if (engine is NuclearEngine)
                {
                    if (!engine.makeRefueling(fuel))
                    {
                        target = null;
                    }
                }
            }
        }

        public void OilFuel(int fuel)
        {
            foreach (var engine in engines)
            {
                if (engine is OilEngine)
                {
                    if (!engine.makeRefueling(fuel))
                    {
                        target = null;
                    }

                }
            }
        }

        private GameEntity getPotentialTarget()
        {
            foreach (SpaceEngine engine in engines)
            {
                if (engine.getCurrentCapacity() < engine.getWarningCapacity())
                {
                    status = SpaceShipStatus.Fuel;
                    if (engine is OilEngine)
                    {
                        return findTheNearest(_space.GetOilFields());
                    } 
                    else if (engine is SolarEngine)
                    {
                        return findTheNearest(_space.GetStars());
                    } 
                    else
                    {
                        return findTheNearest((_space.GetSpaceStations()));
                    }
                } 
            }

            status = SpaceShipStatus.Extraction;
            return findTheNearest(_space.GetOilFields());
        }

        private GameEntity findTheNearest<T>( List<T> entities) where T : GameEntity{

            double minDist = double.MaxValue;

            GameEntity minEntity = null;

            foreach (GameEntity entity in entities)
            {
                double dist = DistFromCoordinateToCoordinate(entity.coordinate, this.coordinate);
                if ( dist < minDist)
                {
                    minEntity = entity;
                    minDist = dist;
                } 
            }

            return minEntity;
        }
        
        protected override void Die()
        {
            base.Die();
        }

        private double DistFromCoordinateToCoordinate(Coordinate coordinate1, Coordinate coordinate2)
        {
            return Math.Sqrt(Math.Pow((coordinate2.X - coordinate1.X), 2) + Math.Pow((coordinate2.Y - coordinate1.Y), 2));
        }
    }
}
