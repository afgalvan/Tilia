using System.ComponentModel.DataAnnotations;

namespace Domain.People
{
    public class IdType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public IdType(string name)
        {
            Name = name;
        }

        public IdType()
        {
        }

        public IdType(int id)
        {
            Id = id;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
