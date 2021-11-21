using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Users
{
    public class Privilege
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IList<AccessRole> AccessRoles { get; set; }
    }
}
