using System.ComponentModel.DataAnnotations;

namespace Requests.Auth
{
    public class AuthenticationResponse
    {
        [Required]
        public string Token { get; set; }

        public AuthenticationResponse(string token)
        {
            Token = token;
        }

        public AuthenticationResponse()
        {
        }
    }
}
