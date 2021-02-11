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
            HitShapesGame game;

            //Check that there are 2 arguments provided
            if (args.Length != 2)
            {
                Console.WriteLine("Please provide two arguments.");
                Console.WriteLine("Usage: dotnet run (x-coordinate(int), y-coordinate(int))  \"SHAPE,X,Y,LENGTH,POINTS;CIRCLE,1,2,30,100 \"");
                return 1;
            }

            string pointInput = args[0];
            string shapesInput = args[1];

            try
            {
                game = new HitShapesGame(pointInput, shapesInput);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Usage: dotnet run (x-coordinate(int), y-coordinate(int))  \"SHAPE,X,Y,LENGTH,POINTS;CIRCLE,1,2,30,100 \"");
                return 1;
            }

            Console.WriteLine("Your score: " + game.Score());

            return 0;
        }
    }
}
