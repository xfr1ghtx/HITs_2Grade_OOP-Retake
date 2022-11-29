using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxy
{
    public class Coordinate
    {
        private int _x;
        private int _y;

        public Coordinate(int x, int y) 
        {
            _x= x;
            _y= y;
        }

        public int X
        {
            get => _x;
            set => _x = value;
        }

        public int Y
        {
            get => _y;
            set => _y = value;
        }
    }
}
