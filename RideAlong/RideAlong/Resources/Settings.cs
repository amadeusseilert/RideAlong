using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideAlong.Resources
{
    public static class Settings
    {
        public static readonly String WebServiceURL = "http://localhost/projetosd/";  
    }
    
    public static class API
    {
        public static readonly String API_Locations = "api/locations";
        public static readonly String API_GetRides = "api/search/ride";
    }
}
