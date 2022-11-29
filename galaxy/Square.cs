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
    public class Square
    {
        private SquareStatus _status;
        private Planet _planetHere;
        private Star _starHere;
        private List<SpaceShip> _spaceshipHere;
        private SpaceStation _spaceStationHere;

        public Square() {
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
    }
}
