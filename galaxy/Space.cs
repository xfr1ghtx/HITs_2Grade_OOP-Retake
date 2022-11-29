using galaxy.Entity;
using galaxy.Entity.Celestial_body;
using galaxy.Entity.Spaceships;
using galaxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxy
{
    public class Space
    {
        public Random random;

        private readonly List<SpaceShip> _spaceShips;
        private readonly List<Planet> _planets;
        private readonly List<Star> _stars;
        private readonly List<SpaceStation> _spaceStations;
        private readonly Square[,] _squares;

        const int planetCount = 10;
        const int starsCount = 10;
        const int spaceshipsCount = 5;
        const int spaceStationsCount = 10;

        public Space(Random random)
        {
            _spaceShips = new List<SpaceShip>();
            _planets = new List<Planet>();
            _stars = new List<Star>();
            _spaceStations = new List<SpaceStation>();
            _squares = new Square[1000,1000];
            this.random = random;
            
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    _squares[i,j] = new Square();
                }
            }

            GenerateSpaceObjects();
        }

        private void GenerateSpaceObjects()
        {

            for (var i = 0; i < starsCount; i++)
            {

            }

            for (var i = 0; i < planetCount; i++)
            {

            }

            for (var i = 0; i < spaceStationsCount; i++)
            {

            }

            for (var i = 0; i < spaceshipsCount; i++)
            {
                var spaceShip = SpaceShipFactory.GetRandomSpaceShip(this, random);
                var coordinate = GetFreePointFor(spaceShip, random);
                spaceShip.coordinate = coordinate;
                _spaceShips.Add(spaceShip);
                _squares[coordinate.X, coordinate.Y].SetSpaceShip(spaceShip);
            }
        }

        private Coordinate GetFreePointFor(GameEntity entity, Random rnd)
        {
            if (entity is SpaceShip) 
            {
                return GetFreePointForSpaceship(entity as SpaceShip, rnd);
            }
            else if (entity is Planet)
            {
                return GetFreePointForPlanet(entity as Planet, rnd);
            }
            else if (entity is Star)
            {
                return GetFreePointForStar(entity as Star, rnd);
            }
            else if (entity is SpaceStation) 
            {
                return GetFreePointForSpaceStation(entity as SpaceStation, rnd);
            }
            else
            {
                return null;
            }

        }

        // Функции рассчета точек для объектов

        private Coordinate GetFreePointForSpaceship(SpaceShip ship, Random random)
        {
            while (true)
            {
                var x = random.Next(0, 999);
                var y = random.Next(0, 999);
                if (_squares[x, y].getStatus() != SquareStatus.Free)
                {
                    continue;
                }
                return new Coordinate(x, y);
            }
        }

        private Coordinate GetFreePointForPlanet(Planet planet, Random random)
        {
            while (true)
            {
                var x = random.Next(0, 999);
                var y = random.Next(0, 999);
            }
        }

        private Coordinate GetFreePointForStar(Star star, Random random)
        {
            while (true)
            {
                var x = random.Next(0, 999);
                var y = random.Next(0, 999);
            }
        }

        private Coordinate GetFreePointForSpaceStation(SpaceStation station, Random random)
        {
            while (true)
            {
                var x = random.Next(0, 999);
                var y = random.Next(0, 999);
            }
        }

    }
}
