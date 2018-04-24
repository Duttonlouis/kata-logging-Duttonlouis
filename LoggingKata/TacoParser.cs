using System;
namespace LoggingKata
{
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {
            //logger.LogInfo("Begin parsing");

            if (string.IsNullOrEmpty(line)) { return null; }

            var cells = line.Split(',');

            if (cells.Length < 2)
            {
                logger.LogWarning("You don't have both values to parse");
                return null;
            }

            try
            {
                var longitude = double.Parse(cells[0]);
                var latitude = double.Parse(cells[1]);
                if (longitude > 180.00 || longitude < -180.00)
                {
                    logger.LogError("You don't have a valid max/min longitude");
                    return null;
                }

                if (latitude > 90.00 || latitude < -90.00)
                {
                    logger.LogError("You don't have a valid max/min latitude");
                    return null;
                }

                var point = new Point
                {
                    Longitude = longitude,
                    Latitude = latitude
                };

                return new Tacobell
                {
                    Location = point,
                    Name = cells.Length > 2 ? cells[2].Replace("\"", "") : null
                };
            }
            catch (Exception ex)
            {
                logger.LogError("unable to parse longitude", ex);
                return null;
            }
        }
    }
}