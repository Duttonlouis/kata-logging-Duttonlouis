﻿using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse);
            ITrackable a = null;
            ITrackable b = null;
            double distance = 0;

            foreach (var locA in locations)
            {
                var origin = new GeoCoordinate
                {
                    Latitude = locA.Location.Latitude,
                    Longitude = locA.Location.Longitude,
                    
                };
                foreach (var locB in locations)
                {
                    var destination = new GeoCoordinate
                    {
                        Latitude = locB.Location.Latitude,
                        Longitude = locB.Location.Longitude,
                    };
                    var newDistance = origin.GetDistanceTo(destination);
                    if (newDistance > distance)
                    {
                        a = locA;
                        b = locB;
                        distance = newDistance;
                    }
                }
            }
            Console.WriteLine($"The Greatest furthest tacobells apart are: \n\t{a.Name}\n\t{b.Name}.");
            Console.WriteLine($"And the distance between them is {Math.Round(distance* 0.00062137)} miles.");
            Console.ReadLine();
        }
    }
}
