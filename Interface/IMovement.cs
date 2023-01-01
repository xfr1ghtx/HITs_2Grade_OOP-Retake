using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxy.Interface
{
    public interface IMovement
    {
        Coordinate Move(Coordinate currentCoordinate, Coordinate targetCoordinate);
    }
}
