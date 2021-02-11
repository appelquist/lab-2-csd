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
            //Check that there are 2 arguments provided
            if (args.Length != 2)
            {
                Console.WriteLine("Please provide two arguments.");
                Console.WriteLine("Usage: dotnet run (x-coordinate(int), y-coordinate(int))  \"SHAPE,X,Y,LENGTH,POINTS;CIRCLE,1,2,30,100 \"");
                return 1;
            }

            List<Shape> shapes = new List<Shape>();
            Point guess;
            string shapesInput = args[1];

            //Try to extract the X and Y coordinate from args and instantiate a new Point with those coordinates
            try
            {
                string[] coordinates = args[0].Split(',');
                coordinates[0] = coordinates[0].Trim('(');
                coordinates[0] = coordinates[0].Trim(')');
                coordinates[0] = coordinates[0].Trim(' ');
                coordinates[1] = coordinates[1].Trim('(');
                coordinates[1] = coordinates[1].Trim(')');
                coordinates[1] = coordinates[1].Trim(' ');
                guess = new Point(Convert.ToInt32(coordinates[0]), Convert.ToInt32(coordinates[1]));
            }
            catch
            {
                Console.WriteLine("Point in wrong format.");
                Console.WriteLine("Usage: dotnet run (x-coordinate(int), y-coordinate(int))  shapes");
                return 1;
            }

            //Try to add the shapes from args to the List shapes
            try
            {
                AddShapes(shapesInput, shapes);
            }
            catch
            {
                Console.WriteLine("Shapes in wrong format");
                Console.WriteLine("Usage: dotnet run (x-coordinate(int), y-coordinate(int))  \"SHAPE,X,Y,LENGTH,POINTS;CIRCLE,1,2,30,100 \"");
                return 1;
            }

            Console.WriteLine("Your score: " + guess.Score(shapes));

            return 0;

            //Method that creates shapes and adds them to a List of Shapes
            void AddShapes(string csvShapes, List<Shape> shapes)
            {

                string[] rows = csvShapes.Split(';');
                string[] headers = rows[0].Split(",");

                RemoveSpaces(headers);

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

                    RemoveSpaces(values);

                    //Use the index of every header in order to get the correct value
                    string shape = values[shapeIndex];
                    int x = Convert.ToInt32(values[xIndex]);
                    int y = Convert.ToInt32(values[yIndex]);
                    int length = Convert.ToInt32(values[lengthIndex]);
                    int points = Convert.ToInt32(values[pointsIndex]);

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

            void RemoveSpaces(string[] arr)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = arr[i].Trim(' ');
                }
            }
        }

    }
}
