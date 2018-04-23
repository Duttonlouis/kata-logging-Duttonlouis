
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
        public const string argumentExceptionLongitude   = "Invalid for longitude greater than 180 or less than -180";
        public const string argumentExceptionLatitude = "Invalid for latitude greater than 90 or less than -90";
    }
}
