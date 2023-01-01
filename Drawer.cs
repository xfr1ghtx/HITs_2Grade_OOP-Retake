using galaxy.Entity;
using galaxy.Entity.Celestial_body;
using galaxy.Entity.Spaceships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxy
{
    public class Drawer
    {
        private readonly PictureBox _picture;
        private Bitmap _bitmap;
        public Drawer(PictureBox picture)
        {
            _picture = picture;
            _bitmap = new Bitmap(_picture.Width, _picture.Height);
        }

        public void Draw(List<Planet> planets, List<OilField> oilFields, List<Star> stars, List<SpaceStation> spaceStations, List<SpaceShip> spaceShips) 
        {
            var graph = Graphics.FromImage(_bitmap);
            graph.Clear(Color.Black);

            foreach (var star in stars)
            {
                var coordinate = star.coordinate;
                
                var radious = star.getBodyRadius() + star.getDeathRadius() + star.getEnergyRadius();

                var fullDeathRadius = star.getBodyRadius() + star.getDeathRadius();

                var bodyRadius = star.getBodyRadius();

                graph.FillEllipse(Brushes.Yellow, star.coordinate.X - radious, star.coordinate.Y - radious, radious * 2, radious * 2);

                graph.FillEllipse(Brushes.Orange, star.coordinate.X - fullDeathRadius, star.coordinate.Y - fullDeathRadius, fullDeathRadius * 2, fullDeathRadius * 2);

                graph.FillEllipse(Brushes.Red, star.coordinate.X - bodyRadius, star.coordinate.Y - bodyRadius, bodyRadius * 2, bodyRadius * 2);


            }

            foreach (var planet in planets)
            {
                var coordinate = planet.coordinate;

                var radious = planet.getBodyRadius();

                graph.FillEllipse(Brushes.Green, planet.coordinate.X - radious, planet.coordinate.Y - radious, radious * 2, radious * 2);
            }

            foreach (var oilField in oilFields)
            {
                var coordinate = oilField.coordinate;
                graph.FillRectangle(Brushes.Brown, new Rectangle(coordinate.X, coordinate.Y, 3, 3));
            }

            foreach (var spaceStation in spaceStations)
            {
                var coordinate = spaceStation.coordinate;
                graph.FillRectangle(Brushes.Cyan, new Rectangle(coordinate.X, coordinate.Y, 5, 5));
            }

            foreach (var spaceShip in spaceShips)
            {
                var coordinate = spaceShip.coordinate;
                graph.FillRectangle(Brushes.Gray, new Rectangle(coordinate.X, coordinate.Y, 3, 3));
            }

            _picture.Image = _bitmap;
           
        }
    }
}
