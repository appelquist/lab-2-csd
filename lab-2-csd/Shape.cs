using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2_csd
{
    public abstract class Shape
    {
        public int xCoordinate { get; protected set; }
        public int yCoordinate { get; protected set; }
        public int circumference { get; protected set; }
        public int instancePoints { get; protected set; }
        public int typePoints { get; protected set; }
        public abstract double Area();
        public abstract bool isPointInside(Point point);
        public double ShapeScore()
        {
            return (this.typePoints * this.instancePoints) / Area();
        }
    }
}
