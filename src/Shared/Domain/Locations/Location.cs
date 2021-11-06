namespace Domain.Locations
{
    public class Location
    {
        public string Id         { get; set; }
        public string City       { get; set; }
        public string Department { get; set; }

        public Location(string id, string city, string department)
        {
            Id         = id;
            City       = city;
            Department = department;
        }
    }
}
