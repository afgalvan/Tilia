using Domain.Locations;
using Domain.MedicalFiles;
using Domain.People;

namespace Domain.Patients
{
    public class Patient : Person
    {
        public string      Occupation  { get; set; }
        public string      Studies     { get; set; }
        public SportsData  SportsData  { get; set; }
        public ContactData ContactData { get; set; }
        public MedicalFile MedicalFile { get; set; }

        public Patient(PersonId id, PersonName names, Genre genre, Location location,
            SportsData sportsData, ContactData contactData) : base(id, names, genre, location)
        {
            SportsData  = sportsData;
            ContactData = contactData;
        }
    }
}
