using System;
using System.ComponentModel.DataAnnotations;
using Domain.Locations;

namespace Domain.People
{
    public class Person
    {
        [Key]
        public string Id { get; set; }

        public IdType     IdType    { get; set; }
        public PersonName Names     { get; set; }
        public Genre      Genre     { get; set; }
        public City       City      { get; set; }
        public DateTime   BirthDate { get; set; }

        public int Age => (BirthDate - DateTime.Now).Days;

        public Person(string id, string idType, string firstName, string lastName,
            Genre genre, string locationId, string city, Department department)
        {
            Id     = id;
            IdType = new IdType(idType);
            Names  = new PersonName(firstName, lastName);
            Genre  = genre;
            City   = new City(locationId, city, department);
        }

        public Person()
        {
            // For EF
        }
    }
}
