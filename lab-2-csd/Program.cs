﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace lab_2_csd
{
    class Program
    {
        
        static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Please provide two arguments.");
                Console.WriteLine("Usage: dotnet run <shapes (x-coordinate(int), y-coordinate(int))>");
                return 1;
            }

            List<Shape> shapes = new List<Shape>();
            Point guess;
            string shapesInput = args[0];

            try
            {
                string[] coordinates = args[1].Split(',');
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
                Console.WriteLine("Usage: dotnet run <shapes, (x-coordinate(int), y-coordinate(int))>");
                return 1;
            }

            if (!AddShapes(shapesInput))
            {
                Console.WriteLine("Please provide shapes in csv format");
                Console.WriteLine("Usage: dotnet run <\"SHAPE,X,Y,LENGTH,POINTS;CIRCLE,3,1,13,100;\", (x-coordinate(int), y-coordinate(int)");
                return 1;
            }


            Console.WriteLine("Your score: " + guess.Score(shapes));

            return 0;

            bool AddShapes(string csvShapes)
            {
                try
                {
                    csvShapes.Trim('"');

                    string[] rows = csvShapes.Split(';');
                    string[] headers = rows[0].Split(",");

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

                        string shape = values[shapeIndex].Trim(' ');
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
                catch
                {
                    return false;
                }
                return true;
            }
        }
        
    }
}
