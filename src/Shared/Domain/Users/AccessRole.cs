using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Users
{
    public class AccessRole
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; }

        public IList<Privilege> Privileges { get; set; }

        public AccessRole()
        {
            Privileges = new List<Privilege>();
        }

        public void AddPrivilege(Privilege privilege)
        {
            Privileges.Add(privilege);
        }
    }
}
