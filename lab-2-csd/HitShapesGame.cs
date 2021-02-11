using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab_2_csd
{
    public class HitShapesGame
    {
        private List<Shape> shapes = new List<Shape>();
        private Point guess;

        public HitShapesGame(string point, string csvShapes)
        {
            try
            {
                string[] coordinates = point.Split(',');
                coordinates[0] = coordinates[0].Trim('(');
                coordinates[0] = coordinates[0].Trim(')');
                coordinates[0] = coordinates[0].Trim(' ');
                coordinates[1] = coordinates[1].Trim('(');
                coordinates[1] = coordinates[1].Trim(')');
                coordinates[1] = coordinates[1].Trim(' ');
                this.guess = new Point(Convert.ToInt32(coordinates[0]), Convert.ToInt32(coordinates[1]));
            }
            catch
            {
                throw new Exception("Point in wrong format");
            }
            try 
            {
                AddShapes(csvShapes);
            }
            catch
            {
                throw new Exception("Shapes in wrong format");
            }
            
        }

        public int Score()
        {
            double hitScore = 0;
            double missScore = 0;

            foreach (Shape shape in shapes)
            {
                if (shape.isPointInside(guess))
                {
                    hitScore += shape.ShapeScore();
                }
                else if (!shape.isPointInside(guess))
                {
                    missScore += shape.ShapeScore();
                }
            }

            return (int)Math.Round(hitScore - (0.25 * missScore));
        }
        private void AddShapes(string csvShapes)
        {
            string[] rows = csvShapes.Split(';');
            string[] headers = rows[0].Split(",");

            for (int i = 0; i < headers.Length; i++)
            {
                headers[i] = headers[i].Trim(' ');
            }

            //Get the index of every header
            int shapeIndex = Array.IndexOf(headers, "SHAPE");
            int xIndex = Array.IndexOf(headers, "X");
            int yIndex = Array.IndexOf(headers, "Y");
            int lengthIndex = Array.IndexOf(headers, "LENGTH");
            int pointsIndex = Array.IndexOf(headers, "POINTS");

            rows = rows.Skip(1).ToArray();

            foreach (string row in rows)
            {
                if (row == "") { break; }

                string[] values = row.Split(",");

                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim(' ');
                }

                //Use the index of every header in order to get the correct value
                string shape = values[shapeIndex];
                int x = Convert.ToInt32(values[xIndex]);
                int y = Convert.ToInt32(values[yIndex]);
                int length = Convert.ToInt32(values[lengthIndex]);
                int points = Convert.ToInt32(values[pointsIndex]);

                if (shape == "CIRCLE")
                {
                    this.shapes.Add(new Circle(x, y, length, points));
                }
                else if (shape == "SQUARE")
                {
                    this.shapes.Add(new Square(x, y, length, points));
                }
                else
                {
                    throw new Exception("Shapes in wrong format");
                }
            }
        }
    }
}
