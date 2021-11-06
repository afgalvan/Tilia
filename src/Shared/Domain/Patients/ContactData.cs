using Domain.Locations;

namespace Domain.Patients
{
    public class ContactData
    {
        public string Address     { get; set; }
        public City   City        { get; set; }
        public int    Stratum     { get; set; }
        public string PhoneNumber { get; set; }
        public string Landline    { get; set; }
    }
}
