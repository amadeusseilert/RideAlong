using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideAlong.Entities
{
    public class User
    {
        public User()
        {

        }

        public Int64 id { get; set; }
        public String name { get; set; }
        //public String profile { get; set; }
        public int rating { get; set; }
    }
}
