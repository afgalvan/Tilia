using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tilia.Web.Controllers
{
    [Route("api/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [Authorize]
        [HttpGet("private")]
        public ActionResult Private() => Ok(new
        {
            Name = "Private Route",
        });

        [HttpGet("{regex(^doc)}")]
        public ActionResult Documentation() => Redirect("swagger/index.html");
    }
}
