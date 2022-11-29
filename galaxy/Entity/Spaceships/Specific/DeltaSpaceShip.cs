﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using galaxy.Entity.Spaceships.Engine;

namespace galaxy.Entity.Spaceships
{
    public class DeltaSpaceShip : SpaceShip
    {
        public DeltaSpaceShip(Space space) : base(space) 
        {
            vision = 30;
            status = SpaceShipStatus.inSearch

            for (int i = 0; i < 2; i++)
            {
                engines.Add(EngineFactory.GetRandomEngine(space.random));

            }

            movement = ;
        }
    }
}