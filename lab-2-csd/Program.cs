using System;
using System.Collections.Generic;
using System.IO;

namespace lab_2_csd
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();

            Console.WriteLine("Guess a point! The more shapes you hit the more points you get, different shapes give different scores!");
            Console.WriteLine("Enter a x coordinate: ");
            int xCoordinate = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a y coordinate: ");
            int yCoordinate = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter shapes: (in CSV format: SHAPE, X, Y, LENGTH, POINTS)");
            string csvShapes = Console.ReadLine();

            string[] rows = csvShapes.Split(';');
            foreach (string row in rows)
            {
                string[] values = row.Split(",");

                string shape = values[0];
                int x= Convert.ToInt32(values[1]);
                int y = Convert.ToInt32(values[2]);
                int length = Convert.ToInt32(values[3]);
                int points = Convert.ToInt32(values[4]);

                if (shape == "CIRCLE")
                {
                    shapes.Add(new Circle(x, yCoordinate, length, points));
                }
                if (shape == "SQUARE")
                {
                    shapes.Add(new Square(x, yCoordinate, length, points));
                }
            }
        }
    }
}
