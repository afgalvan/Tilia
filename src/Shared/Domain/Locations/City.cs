using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Locations
{
    public class City
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("department_id")]
        public Department Department { get; set; }

        public City(string id, string name, Department department)
        {
            Id         = id;
            Name       = name;
            Department = department;
        }

        public City()
        {
        }

        public City(string id)
        {
            Id = id;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
