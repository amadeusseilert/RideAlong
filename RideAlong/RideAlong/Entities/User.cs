using SQLite.Net.Attributes;
using System;

namespace RideAlong.Entities
{
    public class User
    {
        public User()
        {

        }

        [PrimaryKey]
        public long ID { get; set; }
        public String Name { get; set; }
        public int Rating { get; set; }
    }
}
