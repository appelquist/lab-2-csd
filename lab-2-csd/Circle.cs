using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2_csd
{
    public class Circle : Shape
    {
        public Circle(int xCoordinate, int yCoordinate, int circumference, int instancePoints)
        {
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
            this.circumference = circumference;
            this.instancePoints = instancePoints;
            this.typePoints = 2;
        }

        public override double Area()
        {
            double area = (Math.Pow(this.circumference, 2)) / (Math.PI * 4);
            return area;
        }

        public override bool isPointInside(Point point)
        {
            double radius = this.circumference / (2 * Math.PI);

            int circleX = this.xCoordinate;
            int circleY = this.yCoordinate;
            int pointX = point.xCoordinate;
            int pointY = point.yCoordinate;

            double distance = Math.Sqrt(Math.Pow(pointX - circleX, 2) + Math.Pow(pointY - circleY, 2));

            if (distance < radius)
            {
                return true;
            }
            else return false;

        }
    }
}
