using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Employees
{
    public class SanitaryRole
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public SanitaryRole(string name)
        {
            Name = name;
        }

        public SanitaryRole()
        {
        }
    }
}
