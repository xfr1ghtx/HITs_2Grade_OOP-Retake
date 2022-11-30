using galaxy.Entity.Celestial_body;
using galaxy.Entity.Spaceships;
using galaxy.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxy
{
    public class Square : GameEntity
    {
        private SquareStatus _status;
        private Planet _planetHere;
        private OilField _oilFieldHere;
        private Star _starHere;
        private bool isDeath;
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
            this.isDeath = isDeath;
            this.isEnergy = isEnergy;
            _status = SquareStatus.Star;
        }

        public int GetOilFuel()
        {
            int fuel = _oilFieldHere.getFuel();
            if ( fuel > 0 )
            {
                return fuel;
            } else
            {
                _oilFieldHere = null;
                _status = SquareStatus.Planet;
                return 0;
            }
        }

        public int GetNuclearFuel()
        {
            int fuel = _spaceStationHere.getFuel();
            if ( fuel > 0 )
            {
                return fuel;
            } else
            {
                _spaceStationHere = null;
                _status = SquareStatus.Free;
                return 0;
            }
        }
    }
}
