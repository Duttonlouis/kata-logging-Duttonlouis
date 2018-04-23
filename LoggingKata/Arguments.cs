
namespace LoggingKata
{
    class Argu
    {
        public const string longitude = "longitude";
        public const string latitude = "latitude";
        public const double maxLongitude = 180.00;
        public const double minLongitude = -180.00;
        public const double maxLatitude = 90.00;
        public const double minLatitude = -90.00;
        public const string argumentExceptionLongitude = "Invalid Value for longitude greater than 180.00 or less than -180.00";
        public const string argumentExceptionLatitude = "Invalid Value for latitude greater than 90.00 or less than -90.00";
    }
}
