using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace lab_2_csd
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();
            int score;

            Console.WriteLine("Guess a point! The more shapes you hit the more points you get, different shapes give different scores!");

            //Ask for x coordinate and store in variable
            Console.WriteLine("Enter a x coordinate: ");
            int xCoordinate = Convert.ToInt32(Console.ReadLine());

            //Ask for y coordinate and store in variable
            Console.WriteLine("Enter a y coordinate: ");
            int yCoordinate = Convert.ToInt32(Console.ReadLine());

            //User specified point
            Point point = new Point(xCoordinate, yCoordinate);

            //Ask for shapes in csv format and store in variable
            Console.WriteLine("Enter shapes: (in CSV format: SHAPE, X, Y, LENGTH, POINTS)");
            string csvShapes = Console.ReadLine();

            AddShapes(csvShapes);
            Console.WriteLine("Your score: " + point.Score(shapes));


            void AddShapes(string csvShapes)
            {
                string[] rows = csvShapes.Split(';');
                rows = rows.Skip(1).ToArray();
                foreach (string row in rows)
                {
                    if(row == "") { break; }

                    string[] values = row.Split(",");

                    string shape = values[0].Trim(' ');
                    int x = Convert.ToInt32(values[1]);
                    int y = Convert.ToInt32(values[2]);
                    int length = Convert.ToInt32(values[3]);
                    int points = Convert.ToInt32(values[4]);
                    if (shape == "CIRCLE")
                    {
                        shapes.Add(new Circle(x, y, length, points));
                    }
                    if (shape == "SQUARE")
                    {
                        shapes.Add(new Square(x, y, length, points));
                    }
                }
            }
        }
        
    }
}
