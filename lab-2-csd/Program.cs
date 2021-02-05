using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace lab_2_csd
{
    class Program
    {
        
        static int Main(string[] args)
        {
            Console.WriteLine(args[0]);
            if (args.Length != 2)
            {
                Console.WriteLine("Please provide two arguments.");
                Console.WriteLine("Usage: dotnet run <shapes (x-coordinate(int), y-coordinate(int))>");
                return 1;
            }

            List<Shape> shapes = new List<Shape>();
            string shapesInput = args[0];
            int xInput = Convert.ToInt32(args[1][0]);
            int yInput = Convert.ToInt32(args[1][1]);
            Console.WriteLine(xInput);
            //string[] coordinatesInput = args[1].Split(',');
            //coordinatesInput[0].Trim('(');
            //coordinatesInput[1].Trim(')');

            if (!AddShapes(shapesInput))
            {
                Console.WriteLine("Please provide shapes in csv format");
                Console.WriteLine("Usage: dotnet run <\"SHAPE,X,Y,LENGTH,POINTS;CIRCLE,3,1,13,100;\"");
                return 1;
            }

            if (!(int.TryParse(args[1][0], out int output) && int.TryParse(args[1][1], out _)))
            {
                Console.WriteLine("Second argument shoul be of type integer");
                Console.WriteLine("Usage: dotnet run <file.csv (x-coordinate(int), y-coordinate(int))>");
                return 1;
            }

            int score;
            return 0;

            ////Ask for x coordinate and store in variable
            //Console.WriteLine("Enter a x coordinate: ");
            //int xCoordinate = Convert.ToInt32(Console.ReadLine());

            ////Ask for y coordinate and store in variable
            //Console.WriteLine("Enter a y coordinate: ");
            //int yCoordinate = Convert.ToInt32(Console.ReadLine());

            ////User specified point
            //Point point = new Point(xCoordinate, yCoordinate);

            ////Ask for shapes in csv format and store in variable
            //Console.WriteLine("Enter shapes: (in CSV format: SHAPE, X, Y, LENGTH, POINTS)");
            //string csvShapes = Console.ReadLine();

            //AddShapes(csvShapes);
            //Console.WriteLine("Your score: " + point.Score(shapes));


            bool AddShapes(string csvShapes)
            {
                try
                {
                    csvShapes.Trim('"');
                    string[] rows = csvShapes.Split(';');
                    rows = rows.Skip(1).ToArray();
                    foreach (string row in rows)
                    {
                        if (row == "") { break; }

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
                catch
                {
                    return false;
                }
                return true;
            }
        }
        
    }
}
