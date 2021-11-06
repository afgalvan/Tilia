using System;
using Domain.Locations;

namespace Domain.People
{
    public class Person
    {
        public PersonId   Id        { get; set; }
        public PersonName Names     { get; set; }
        public Genre      Genre     { get; set; }
        public Location   Location  { get; set; }
        public DateTime   BirthDate { get; set; }

        public int Age => (BirthDate - DateTime.Now).Days;

        public Person(string code, string idType, string firstName, string lastName,
            Genre genre, string locationId, string city, string department)
        {
            Id       = new PersonId(code, idType);
            Names    = new PersonName(firstName, lastName);
            Genre    = genre;
            Location = new Location(locationId, city, department);
        }
    }
}
