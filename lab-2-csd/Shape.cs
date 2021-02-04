using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2_csd
{
    public abstract class Shape
    {
        public int xCoordinate { get; set; }
        public int yCoordinate { get; set; }
        public int circumference { get; set; }
        public int instancePoints { get; set; }
        public int typePoints { get; set; }
        public abstract double Area();
        public abstract bool isPointInside(Point point);
        public double ShapeScore()
        {
            return (this.typePoints * this.instancePoints) / Area();
        }
    }
}
