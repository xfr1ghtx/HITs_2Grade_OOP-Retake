using galaxy
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxy.Interface
{
    public interface IMovement
    {
        Tuple<Coordinate, Coordinate> GetNextCoordinateFromScan(Coordinate currentCoordinate, int vision, Random random);
        Coordinate GetNextCoordinateToTarget(Coordinate currentCoordinate, Coordinate targetCoordinate);

    }
}
