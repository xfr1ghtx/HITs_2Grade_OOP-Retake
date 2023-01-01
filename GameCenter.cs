using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace galaxy
{
    public class GameCenter
    {
        private readonly Drawer _drawer;
        private readonly Space _space;
        private readonly Random _random;

        public GameCenter(PictureBox picture, Form1 form)
        {
            _random= new Random();
            _space = new Space(_random);
            _drawer= new Drawer(picture);
        }

        public void Play()
        {
            var planets = _space.GetPlanets();
            var oilFields = _space.GetOilFields();
            var stars = _space.GetStars();
            var stations = _space.GetSpaceStations();
            var ships = _space.GetSpaceShips();

            _drawer.Draw(planets, oilFields, stars, stations, ships);

            foreach (var ship in ships.ToArray())
            {
                ship.Play(_random);
            }
        }

    }
}
