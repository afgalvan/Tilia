using System.ComponentModel.DataAnnotations;

namespace Requests.Users
{
    public class CreateUserRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
