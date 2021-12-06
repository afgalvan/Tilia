using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Locations;

namespace Domain.People
{
    [Table("people")]
    public class Person
    {
        [Key]
        public string PersonId { get; set; }

        [ForeignKey("identification_type_id")]
        public IdType IdType { get; set; }

        public string   FirstName { get; set; }
        public string   LastName  { get; set; }
        public Genre    Genre     { get; set; }
        public City     City      { get; set; }
        public DateTime BirthDate { get; set; }

        public int Age => DateTime.Now.Year - BirthDate.Year;

        public Person(string personId, string idType, string firstName, string lastName,
            Genre genre, string locationId, string city, Department department)
        {
            PersonId  = personId;
            IdType    = new IdType(idType);
            FirstName = firstName;
            LastName  = lastName;
            Genre     = genre;
            City      = new City(locationId, city, department);
        }

        public Person()
        {
            // For EF
        }

        public override string ToString()
        {
            return FirstName;
        }
    }
}
