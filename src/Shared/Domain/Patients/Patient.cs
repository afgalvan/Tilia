using System.ComponentModel.DataAnnotations.Schema;
using Domain.Locations;
using Domain.People;

namespace Domain.Patients
{
    [Table("patients")]
    public class Patient : Person
    {
        public string      Occupation  { get; set; }
        public string      Studies     { get; set; }
        public SportsData  SportsData  { get; set; }
        public ContactData ContactData { get; set; }

        public Patient(string personId, string idType, string firstName, string lastName,
            Genre genre, string locationId, string city, Department department,
            SportsData sportsData, ContactData contactData) : base(personId, idType, firstName,
            lastName, genre, locationId, city, department)
        {
            SportsData  = sportsData;
            ContactData = contactData;
        }

        public Patient()
        {
            // For EF
        }
    }
}
