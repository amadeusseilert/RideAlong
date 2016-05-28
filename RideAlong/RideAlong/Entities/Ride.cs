using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideAlong.Entities
{
    class Ride
    {

        public Ride()
        {

        }

        public string driver { get; set; }
        public string origin { get; set; }
        public string destination { get; set; }
        public int slots { get; set; }
        public DateTime dateTime { get; set; }

        
    }
}
