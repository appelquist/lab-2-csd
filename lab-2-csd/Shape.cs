using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2_csd
{
    public class Shape
    {
        int xCoordinate;
        int yCoordinate;
        int circumference;
        int instancePoints;
        int typePoints;

        public Shape(int xCoordinate, int yCoordinate, int circumference, int instancePoints)
        {
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
            this.circumference = circumference;
            this.instancePoints = instancePoints;
        }
    }
}
