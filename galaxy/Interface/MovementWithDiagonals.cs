using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxy.Interface
{
    public class MovementWithDiagonals : IMovement
    {
        public Coordinate Move(Coordinate currentCoordinate, Coordinate targetCoordinate)
        {
            var x = targetCoordinate.X - currentCoordinate.X;
            var y = targetCoordinate.Y - currentCoordinate.Y;
            if (x == 0 && y == 0)
                return new Coordinate(0, 0);
            if (x == 0)
            {
                if (y > 0)
                    return new Coordinate(0, 1);
                return new Coordinate(0, -1);
            }

            if (y == 0)
            {
                if (x > 0)
                    return new Coordinate(1, 0);
                return new Coordinate(-1, 0);
            }

            if (x > 0)
            {
                if (y > 0)
                    return new Coordinate(1, 1);
                return new Coordinate(1, -1);
            }

            if (y > 0)
                return new Coordinate(-1, 1);
            return new Coordinate(-1, -1);
        }
    }
}
