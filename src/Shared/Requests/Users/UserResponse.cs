using System.ComponentModel.DataAnnotations;

namespace Requests.Users
{
    public class UserResponse
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
