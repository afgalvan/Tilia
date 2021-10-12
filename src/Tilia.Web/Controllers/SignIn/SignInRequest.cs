using System.ComponentModel.DataAnnotations;

namespace Tilia.Web.Controllers.SignIn
{
    public class SignInRequest
    {
        [Required]
        public string UsernameOrEmail { get; init; }

        [Required]
        public string Password { get; init; }
    }
}
