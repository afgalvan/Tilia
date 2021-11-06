using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Employees;

namespace Domain.Users
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Email Email { get; set; }

        [Required]
        public string Password { get; set; }

        [ForeignKey("access_role_id")]
        public AccessRole AccessRole { get; set; }

        [ForeignKey("employee_id")]
        public Employee Employee { get; set; }

        public User(string name, string email, string password, AccessRole accessRole,
            Employee employee)
        {
            Name       = name;
            Email      = new Email(email);
            Password   = password;
            AccessRole = accessRole;
            Employee   = employee;
        }

        public User()
        {
            // For EF
        }
    }
}
