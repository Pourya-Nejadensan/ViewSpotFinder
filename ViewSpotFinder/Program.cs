using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using ViewSpotFinder.Util;

namespace ViewSpotFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger.Initialize("log.txt");

            if (args.Length < 2)
            {
                Console.WriteLine("Usage: ViewSpotFinder.exe <mesh file> <number of view spots>");
                Logger.Log(LogLevel.Warning, "Usage: ViewSpotFinder.exe <mesh file> <number of view spots>");
                Console.ReadKey();
                Environment.Exit(1);
            }

            string meshFile = args[0];
            int numViewSpots = int.Parse(args[1]);

            ViewSpotFinder finder = new ViewSpotFinder();
            List<Dictionary<string, object>> result = finder.FindViewSpots(meshFile, numViewSpots);

            string jsonResult = JsonConvert.SerializeObject(result, Formatting.Indented);

            if (jsonResult != "null")
            {
                Console.WriteLine(jsonResult);
            }
            else
            {
                Console.WriteLine("Please check the log file!");
            }
            Console.ReadKey();
        }
    }
}
