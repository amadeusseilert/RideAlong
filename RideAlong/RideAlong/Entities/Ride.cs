using SQLite.Net.Attributes;

namespace RideAlong.Entities
{
    public class Ride
    {

        public Ride()
        {

        }

        [PrimaryKey]
        public string ID { get; set; }
        public string Context { get; set; }
        public string Driver { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int Slots { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

    }
}
