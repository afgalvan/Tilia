using System.ComponentModel.DataAnnotations;

namespace SharedLib.Auth
{
    public class AccessToken
    {
        [Required]
        public string Token { get; set; }
    }
}
