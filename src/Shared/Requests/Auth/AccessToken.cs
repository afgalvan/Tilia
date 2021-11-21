using System.ComponentModel.DataAnnotations;

namespace Requests.Auth
{
    public class AccessToken
    {
        [Required]
        public string Bearer { get; set; }

        public AccessToken(string bearer)
        {
            Bearer = bearer;
        }

        public AccessToken()
        {
        }
    }
}
