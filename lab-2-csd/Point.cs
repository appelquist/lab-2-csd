using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2_csd
{
    public class Point
    {
        public int xCoordinate { get; private set; }
        public int yCoordinate { get; private set; }

        public Point(int xCoordinate, int yCoordinate)
        {
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
        }
    }
}
