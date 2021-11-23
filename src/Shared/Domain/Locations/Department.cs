using System.ComponentModel.DataAnnotations;

namespace Domain.Locations
{
    public class Department
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public Department(string id, string name)
        {
            Id   = id;
            Name = name;
        }

        public Department()
        {
            // For EF
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
