using galaxy.Entity;
using galaxy.Entity.Celestial_body;
using galaxy.Entity.Spaceships;
using galaxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

namespace galaxy
{
    public class Space
    {
        public Random random;

        private readonly List<SpaceShip> _spaceShips;
        private readonly List<Planet> _planets;
        private readonly List<OilField> _oilFields;
        private readonly List<Star> _stars;
        private readonly List<SpaceStation> _spaceStations;
        private readonly Square[,] _squares;

        private const int planetCount = 30;
        private const int starsCount = 50;
        private const int spaceshipsCount = 1000;
        private const int spaceStationsCount = 50;

        public Space(Random random)
        {
            _spaceShips = new List<SpaceShip>();
            _planets = new List<Planet>();
            _oilFields= new List<OilField>();
            _stars = new List<Star>();
            _spaceStations = new List<SpaceStation>();
            _squares = new Square[2000,2000];
            this.random = random;
            
            for (int i = 0; i < 2000; i++)
            {
                for (int j = 0; j < 2000; j++)
                {
                    _squares[i,j] = new Square(this);
                    _squares[i,j].coordinate = new Coordinate (j, i); 
                }
            }

            GenerateSpaceObjects();
        }

        private void GenerateSpaceObjects()
        {

            for (var i = 0; i < starsCount; i++)
            {
                var star = new Star(this);
                var coordinate = GetFreePointFor(star, random);
                star.coordinate = coordinate;
                _stars.Add(star);
                _squares[coordinate.X, coordinate.Y].SetStar(star,true, false);

                var radious = star.getBodyRadius() + star.getDeathRadius() + star.getEnergyRadius();
                
                for (int j = coordinate.Y - radious; j <= coordinate.Y + radious; j++)
                {
                    for (int k = coordinate.X - radious; k <= coordinate.X + radious; k++)
                    {
                        if (j > 0 && k > 0 && k < 2000 && j < 2000)
                        {

                            var currentDist = DistFromCoordinateToCoordinate(new Coordinate(k, j), star.coordinate);

                            if (currentDist <= radious && currentDist >= (star.getBodyRadius() + star.getDeathRadius())) {
                                _squares[k, j].SetStar(star, false, true);
                            } 
                            else if (currentDist <= star.getBodyRadius() + star.getDeathRadius())
                            {
                                _squares[k,j].SetStar(star, true, false);
                            } else
                            {
                                _squares[k, j].SetStar(star, false, false);
                            }
                        }
                    }
                }
            }

            for (var i = 0; i < planetCount; i++)
            {
                var planet = new Planet(this);
                var coordinate = GetFreePointFor(planet, random);
                planet.coordinate = coordinate;
                _planets.Add(planet);
                _squares[coordinate.X, coordinate.Y].SetPlanet(planet);

                for (int j = coordinate.Y - planet.getBodyRadius(); j <= coordinate.Y + planet.getBodyRadius(); j++)
                {
                    for (int k = coordinate.X - planet.getBodyRadius(); k <= coordinate.X + planet.getBodyRadius(); k++)
                    {
                        if (j > 0 && k > 0 && k < 2000 && j < 2000)
                        {
                            var currentDist = DistFromCoordinateToCoordinate(new Coordinate(k, j), planet.coordinate);

                            if (currentDist <= planet.getBodyRadius())
                            {
                                OilField oilField = null;
                                if (random.Next(1,100) == 17)
                                {
                                    oilField = new OilField(this);
                                    oilField.coordinate = new Coordinate(k, j);
                                    _squares[k,j].SetOilField(oilField);
                                }

                                _squares[k,j].SetPlanet(planet);

                                if (oilField != null) {
                                    _oilFields.Add(oilField);
                                }
                            }
                            else
                            {
                                _squares[k, j].SetPlanet(planet);
                            }
                        }
                    }
                }

            }

            for (var i = 0; i < spaceStationsCount; i++)
            {
                var spaceStation = new SpaceStation(this);
                var coordinate = GetFreePointFor(spaceStation, random);
                spaceStation.coordinate = coordinate;
                _spaceStations.Add(spaceStation);
                _squares[coordinate.X, coordinate.Y].SetSpaceStation(spaceStation);
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
                var x = random.Next(0, 2000);
                var y = random.Next(0, 2000);
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
                var x = random.Next(0, 2000);
                var y = random.Next(0, 2000);

                var planetRadius = planet.getBodyRadius();
                
                if (CanSetCelestialBodyOn(new Coordinate(x, y), planetRadius))
                {
                    return new Coordinate(x, y);
                } else
                {
                    continue;
                }

            }
        }

        private Coordinate GetFreePointForStar(Star star, Random random)
        {
            while (true)
            {
                var x = random.Next(0, 2000);
                var y = random.Next(0, 2000);

                var starRadius = star.getBodyRadius() + star.getDeathRadius() + star.getEnergyRadius();

                if (CanSetCelestialBodyOn(new Coordinate(x, y), starRadius)) {
                    return new Coordinate(x, y);
                } else
                {
                    continue;
                }
            }
        }

        private Coordinate GetFreePointForSpaceStation(SpaceStation station, Random random)
        {
            while (true)
            {
                var x = random.Next(0, 2000);
                var y = random.Next(0, 2000);

                if (_squares[x,y].getStatus() == SquareStatus.Free)
                {
                    return new Coordinate(x, y);
                } else
                {
                    continue;
                }
            }
        }

        private bool CanSetCelestialBodyOn(Coordinate coordinate, int radious)
        {
            for (int i = coordinate.X - radious; i <= coordinate.X + radious; i++)
            {
                for (int k = coordinate.Y - radious; k <= coordinate.Y + radious; k++)
                {
                    if (i >= 0 && k >= 0 && i < 2000 && k < 2000)
                    {
                        if (_squares[i, k].getStatus() != SquareStatus.Free)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public List<Planet> GetPlanets()
        {
            return _planets;
        }

        public List<Star> GetStars()
        {
            return _stars;
        }

        public List<SpaceStation> GetSpaceStations()
        {
            return _spaceStations;
        }

        public List<SpaceShip> GetSpaceShips()
        {
            return _spaceShips;
        }

        public List<OilField> GetOilFields()
        {
            return _oilFields;
        }

        private double DistFromCoordinateToCoordinate(Coordinate coordinate1, Coordinate coordinate2)
        {
            return Math.Sqrt(Math.Pow((coordinate2.X - coordinate1.X), 2) + Math.Pow((coordinate2.Y - coordinate1.Y), 2));
        }

        public void DeleteSpaceship(SpaceShip spaceShip)
        {
            var coordinate = spaceShip.coordinate;
            _spaceShips.Remove(spaceShip);
            _squares[coordinate.X, coordinate.Y].DeleteSpaceship(spaceShip);
        }

        public void SetSpaceship(SpaceShip spaceShip)
        {
            var coordinate = spaceShip.coordinate;
            if (_squares[coordinate.X, coordinate.Y].IsDeath)
            {
                _spaceShips.Remove(spaceShip);
                return;
            }
            _squares[coordinate.X, coordinate.Y].SetSpaceShip(spaceShip);
        }

        public void StartExtraction(SpaceShip spaceShip)
        {
            var coordinate = spaceShip.coordinate;
            if (_squares[coordinate.X, coordinate.Y].GetOilField() == null)
            {
                return;
            }

            int extraction = _squares[coordinate.X, coordinate.Y].GetOilFuel();

            if (extraction > 0)
            {
                spaceShip.ExtractionOil(extraction);
            }
            else
            {
                spaceShip.DeleteTarget();
                _oilFields.Remove(_squares[coordinate.X, coordinate.Y].GetOilField());
                _squares[coordinate.X, coordinate.Y].DeleteOilField();
            }
        }

        public void Fuel(SpaceShip spaceShip)
        {
            var coordinate = spaceShip.coordinate;
            if (_squares[coordinate.X, coordinate.Y].GetSpaceStation() != null) 
            {
                int fuel = _squares[coordinate.X, coordinate.Y].GetNuclearFuel();
                if (fuel > 0)
                {
                    spaceShip.NuclearFuel(fuel);
                } else
                {
                    spaceShip.DeleteTarget();
                    _spaceStations.Remove(_squares[coordinate.X, coordinate.Y].GetSpaceStation());
                    _squares[coordinate.X, coordinate.Y].DeleteSpaceStation();
                }
            } 
            else if (_squares[coordinate.X, coordinate.Y].GetOilField() != null)
            {
                int fuel = _squares[coordinate.X, coordinate.Y].GetOilFuel();
                if (fuel > 0)
                {
                    spaceShip.OilFuel(fuel);
                }
                else
                {
                    spaceShip.DeleteTarget();
                    _oilFields.Remove(_squares[coordinate.X, coordinate.Y].GetOilField());
                    _squares[coordinate.X, coordinate.Y].DeleteOilField();
                }
            } 
            else if (_squares[coordinate.X, coordinate.Y].isStarEnergy())
            {
                int energy = _squares[coordinate.X, coordinate.Y].GetStarEnergy();
                spaceShip.StarEnergyFuel(energy);
            } 
            else
            {
                spaceShip.DeleteTarget();
                return;
            }
        }

    }
}
