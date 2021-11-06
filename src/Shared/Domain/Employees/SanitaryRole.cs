using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Employees
{
    public class SanitaryRole
    {
        [Key]
        public Guid   Id   { get; set; }
        public string Name { get; set; }
    }
}
