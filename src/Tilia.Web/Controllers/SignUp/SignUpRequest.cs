using System.ComponentModel.DataAnnotations;

namespace Tilia.Web.Controllers.SignUp
{
    public class SignUpRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public SignUpRequest(string username, string email, string password)
        {
            Username = username;
            Email    = email;
            Password = password;
        }

        public override string ToString() =>
            $"{{\nusername: {Username},\nemail: {Email},\npassword: {Password}\n}}";
    }
}
