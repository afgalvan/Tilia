using System.ComponentModel.DataAnnotations;

namespace SharedLib.Auth
{
    public class AccessToken
    {
        [Required]
        public string Bearer { get; set; }
    }
}
