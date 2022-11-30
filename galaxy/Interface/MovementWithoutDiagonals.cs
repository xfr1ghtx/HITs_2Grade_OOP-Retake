using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxy.Interface
{
    public class MovementWithoutDiagonals : IMovement
    {
        public Coordinate Move(Coordinate currentCoordinate, Coordinate targetCoordinate)
        {
            var x = targetCoordinate.X - currentCoordinate.X;
            var y = targetCoordinate.Y - currentCoordinate.Y;

            if (x == 0 && y == 0)
            {
                return new Coordinate(0, 0);
            }
            if (x == 0)
            {
                return y > 0 ? new Coordinate(x, 1) : new Coordinate(x, -1);
            } 
            else
            {
                return x > 0 ? new Coordinate(1, 0) : new Coordinate(-1, 0);
            }
        }
    }
}
