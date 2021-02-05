using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2_csd
{
    public class Point
    {
        public int xCoordinate { get; set; }
        public int yCoordinate { get; set; }

        public Point(int xCoordinate, int yCoordinate)
        {
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
        }

        public int Score(List<Shape> shapes)
        {
            double hitScore = 0;
            double missScore = 0;

            foreach (Shape shape in shapes)
            {
                if (shape.isPointInside(this))
                {
                    hitScore += shape.ShapeScore();
                }
                else if (!shape.isPointInside(this))
                {
                    missScore += shape.ShapeScore();
                }
            }

            return (int)Math.Round(hitScore -  (0.25 * missScore));
        }
    }
}
