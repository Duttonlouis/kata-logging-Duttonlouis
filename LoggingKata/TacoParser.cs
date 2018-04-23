using System;
namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the TacoBells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            if (string.IsNullOrEmpty(line)) { return null; }

            var cells = line.Split(',');

            if (cells.Length < 3)
            {
                return null;
            }
            var longitude = 0.0;
            var latitude = 0.0;
            var name = "";

            // grab the long from your array at index 0
            // grab the lat from your array at index 1
            // grab the name from your array at index 2
            
            
             longitude = double.Parse(cells[0]);
             latitude = double.Parse(cells[1]);
             name = cells[2];





            // Your going to need to parse your string as a `double`
            // which is similar to parse a string as an `int`

            // You'll need to create a TacoBell class
            // that conforms to ITrackable

            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly
            var tacoBell = new Tacobell();
            var point = new Point();
            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable

            
            point.Longitude = longitude;
            point.Latitude = latitude;
            tacoBell.Location = point;
            tacoBell.Name = name.Replace("\"","");
            return tacoBell;

        }
    }
}