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

            try
            {
                longitude = double.Parse(cells[0]);
                if (longitude > Argu.maxLongitude || longitude < Argu.minLongitude)
                {
                    throw new ArgumentOutOfRangeException(Argu.argumentExceptionLongitude);
                }
            }
            catch
            {
                logger.LogError("unable to parse longitude");
                return null;
            }
            try
            {
                latitude = double.Parse(cells[1]);
                if (latitude > Argu.maxLatitude || latitude < Argu.minLatitude)
                {
                    throw new ArgumentOutOfRangeException(Argu.argumentExceptionLatitude);
                }
            }
            catch
            {
                logger.LogError("unable to parse latitude");
                return null;
            }
            try
            {
                name = cells[2];
            }
            catch
            {
                logger.LogError("unable to parse name");
                return null;
            }

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