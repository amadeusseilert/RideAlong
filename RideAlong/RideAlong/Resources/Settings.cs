using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideAlong.Resources
{
    public static class Settings
    {
        public static readonly String WebServiceURL = "http://ec2-52-67-5-21.sa-east-1.compute.amazonaws.com/RideAlong-WebService/";
        public static readonly String DbName = "ride_along.db3";
    }
    
    public static class API
    {
        public static readonly String API_Locations = "api/locations/";
        public static readonly String API_GetRides = "api/search/ride/";
        public static readonly String API_ReserveRide = "api/reserve/ride/UNIFESP/";
    }
}
