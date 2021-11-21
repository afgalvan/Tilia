using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Employees;

namespace Domain.Users
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Correo electrónico inválido")]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [ForeignKey("access_role_id")]
        public AccessRole AccessRole { get; set; }

        [ForeignKey("employee_id")]
        public Employee Employee { get; set; }

        public User(string name, string email, string password)
        {
            Name       = name;
            Email      = email;
            Password   = password;
        }

        public User()
        {
            // For EF
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
