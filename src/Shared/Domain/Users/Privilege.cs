using System.ComponentModel.DataAnnotations;

namespace Domain.Users
{
    public class Privilege
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
