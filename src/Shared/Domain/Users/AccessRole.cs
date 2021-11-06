using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Users
{
    public class AccessRole
    {
        [Key]
        public Guid             Id         { get; set; }
        [Required]
        public string           Name       { get; set; }
        public IList<Privilege> Privileges { get; set; }

        public void AddPrivilege(Privilege privilege)
        {
            Privileges.Add(privilege);
        }
    }
}
