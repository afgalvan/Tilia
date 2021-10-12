using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Tilia.Web.Controllers.SignIn
{
    [Route("api/auth")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        [HttpPost("signIn/{provider}")]
        public IActionResult SignIn([FromRoute] string provider)
        {
            return Challenge(new AuthenticationProperties {RedirectUri = "/"}, provider);
        }
    }
}
