using System.ComponentModel.DataAnnotations.Schema;
using Domain.Locations;

namespace Domain.Patients
{
    public class ContactData
    {
        public string Address { get; set; }

        [ForeignKey("city_id")]
        public City LivingCity { get; set; }

        public int    Stratum     { get; set; }
        public string PhoneNumber { get; set; }
        public string Landline    { get; set; }
    }
}
