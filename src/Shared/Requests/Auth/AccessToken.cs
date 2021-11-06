using System.ComponentModel.DataAnnotations;

namespace Requests.Auth
{
    public class AccessToken
    {
        [Required]
        public string Bearer { get; set; }
    }
}
