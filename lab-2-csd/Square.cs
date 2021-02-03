using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2_csd
{
    public class Square : Shape
    {
        int typePoints = 2;
        public Square(int xCoordinate, int yCoordinate, int circumference, int instancePoints) : base(xCoordinate, yCoordinate, circumference, instancePoints)
        {
        }
    }
}
