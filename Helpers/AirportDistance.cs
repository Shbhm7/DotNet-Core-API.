using AIRPORTAPI.Models;
using System;

namespace AIRPORTAPI.Helpers
{
    public static class AirportDistanceCalculator
    {
         public const double EarthRadiuskm = 6371.0;
        
        public static double CalculateDistance(Airport airport1, Airport airport2)
        {

                double lat1 = ToRadians(airport1.Latitude);
                double lon1 = ToRadians(airport1.Longitude);
                double lat2 = ToRadians(airport2.Latitude);
                double lon2 = ToRadians(airport2.Longitude);

                double dLat = lat2- lat1;
                double dLon = lon2- lon1;

                double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = EarthRadiuskm * c;

            return distance;
        }

        private static double ToRadians(double degrees)
        {
                return degrees * (Math.PI /180);
        }
    }
}