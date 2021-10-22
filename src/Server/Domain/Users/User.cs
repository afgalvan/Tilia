using System;
using System.ComponentModel.DataAnnotations;
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
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public AccessRole AccessRole { get; set; }
        public Employee   Employee   { get; set; }

        public User(string name, string email, string password)
        {
            Name     = name;
            Email    = email;
            Password = password;
        }
    }
}
