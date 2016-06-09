using SQLite.Net.Attributes;
using System;

namespace RideAlong.Entities
{
    public class User
    {
        public User()
        {

        }

        [PrimaryKey, AutoIncrement, Unique]
        public long id_db { get; set; }
        public long id { get; set; }
        public String name { get; set; }
        public int rating { get; set; }
    }
}
