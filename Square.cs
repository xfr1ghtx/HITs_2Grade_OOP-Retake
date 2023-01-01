using galaxy.Entity.Celestial_body;
using galaxy.Entity.Spaceships;
using galaxy.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace galaxy
{
    public class Square : GameEntity
    {
        private SquareStatus _status;
        private Planet _planetHere;
        private OilField _oilFieldHere;
        private Star _starHere;
        public bool IsDeath { get; private set; }
        private bool isEnergy;
        private List<SpaceShip> _spaceshipHere;
        private SpaceStation _spaceStationHere;

        public Square(Space space) : base (space) {
            _status = SquareStatus.Free;
            _planetHere = null;
            _starHere = null;
            _spaceshipHere = new List<SpaceShip>();
            _spaceStationHere = null;
        }

        public SquareStatus getStatus() 
        { 
            return _status; 
        }

        public void SetSpaceShip(SpaceShip spaceShip)
        {
            _spaceshipHere.Add(spaceShip);
            _status = SquareStatus.Spaceship;
        }

        public void DeleteSpaceship(SpaceShip spaceShip) 
        {
            _spaceshipHere.Remove(spaceShip);
            if (_spaceshipHere.Count == 0 ) 
            {
                _status = SquareStatus.Free;
            }
        }

        public OilField GetOilField ()
        {
            return _oilFieldHere;
        }

        public void DeleteOilField()
        {
            _oilFieldHere = null;
            _status = SquareStatus.Planet;
        }

        public void SetOilField(OilField oilField)
        {
            _oilFieldHere = oilField;
            _status = SquareStatus.OilField;
        }

        public void SetPlanet(Planet planet) 
        { 
            _planetHere= planet;
            _status = SquareStatus.Planet;
        }

        public void SetSpaceStation(SpaceStation spaceStation)
        {
            _spaceStationHere= spaceStation;
            _status = SquareStatus.Station;
        }

        public void SetStar(Star star, bool isDeath, bool isEnergy)
        {
            _starHere = star;
            this.IsDeath = isDeath;
            this.isEnergy = isEnergy;
            _status = SquareStatus.Star;
        }

        public int GetStarEnergy()
        {
            if (_starHere == null)
            {
                return 0;
            }
            return _starHere.getStarEnergy();
        }

        public bool isStarEnergy()
        {
            if (_starHere != null && isEnergy && !IsDeath)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public int GetOilFuel()
        {
            if (_oilFieldHere == null)
            {
                return 0;
            }
            int fuel = _oilFieldHere.getFuel();
            if ( fuel > 0 )
            {
                return fuel;
            } else
            {
                return 0;
            }
        }

        public void DeleteSpaceStation()
        {
            _spaceStationHere = null;
            _status = SquareStatus.Free;
        }

        public SpaceStation GetSpaceStation()
        {
            return _spaceStationHere;
        }

        public int GetNuclearFuel()
        {
            if (_spaceStationHere == null)
            {
                return 0;
            }
            int fuel = _spaceStationHere.getFuel();
            if ( fuel > 0 )
            {
                return fuel;
            } else
            {
                return 0;
            }
        }
    }
}
