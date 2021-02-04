using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2_csd
{
    public class Square : Shape
    {
        public Square(int xCoordinate, int yCoordinate, int circumference, int instancePoints)
        {
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
            this.circumference = circumference;
            this.instancePoints = instancePoints;
            this.typePoints = 1;
        }

        public override double Area()
        {
            double area = Math.Pow(this.circumference / 4, 2);
            return area;
        }
        public override bool isPointInside(Point point)
        {
            int side = this.circumference / 4;

            double bottomleftX = this.xCoordinate - (side/2);
            double bottomLeftY = this.yCoordinate - (side / 2);
            double topLeftY = this.yCoordinate + (side / 2);
            double bottomRightX = this.xCoordinate + (side / 2);
            double bottomRightY = this.xCoordinate - (side / 2);

            if (point.xCoordinate > bottomleftX && point.xCoordinate < bottomRightX && point.yCoordinate > bottomLeftY && point.yCoordinate < topLeftY)
            {
                return true;
            }
            else return false;
        }
    }
}