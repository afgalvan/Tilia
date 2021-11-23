using System.ComponentModel.DataAnnotations;

namespace Requests.Auth
{
    public class AuthenticationResponse
    {
        [Required]
        public string Bearer { get; set; }

        public AuthenticationResponse(string bearer)
        {
            Bearer = bearer;
        }

        public AuthenticationResponse()
        {
        }
    }
}
