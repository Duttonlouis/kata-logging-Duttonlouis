using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        //Why do you think we use ILog?
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

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






                // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
                // Create a new corA Coordinate with your locA's lat and long

                // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)
                // Create a new Coordinate with your locB's lat and long
                // Now, compare the two using `origin.GetDistanceTo(distance)`, which returns a double
                // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

                // Once you've looped through everything, you've found the two Taco Bells furthest away from each other.
            }
            Console.WriteLine($"The Greatest distance between two tacobells is {a} and {b}.");
            Console.WriteLine($"And the distance between them is {distance}.");
            Console.ReadLine();
        }
    }
}