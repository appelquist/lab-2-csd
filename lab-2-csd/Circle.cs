using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2_csd
{
    public class Circle : Shape
    {
        int typePoints = 2;
        public Circle(int xCoordinate, int yCoordinate, int circumference, int instancePoints) : base(xCoordinate, yCoordinate, circumference, instancePoints)
        {
        }
    }
}
