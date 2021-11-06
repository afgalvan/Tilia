using System.ComponentModel.DataAnnotations;

namespace Domain.People
{
    public class PersonId
    {
        [Key]
        public string Code   { get; set; }
        public string IdType { get; set; }

        public PersonId(string code, string idType)
        {
            Code   = code;
            IdType = idType;
        }
    }
}
