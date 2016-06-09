using SQLite.Net.Attributes;

namespace RideAlong.Entities
{
    public class Ride
    {

        public Ride()
        {

        }

        [PrimaryKey, AutoIncrement, Unique]
        public int id_db { get; set; }
        public string id { get; set; }
        public string context { get; set; }
        public string driver { get; set; }
        public string origin { get; set; }
        public string destination { get; set; }
        public int slots { get; set; }
        public string date { get; set; }
        public string time { get; set; }

    }
}
