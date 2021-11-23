using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("/")]
    [ApiController]
    public class RootController : ControllerBase
    {
        [HttpGet]
        public ActionResult Index() => Ok(new
        {
            Name          = "Tilia API",
            Documentation = $"{HttpContext.Request.GetDisplayUrl()}documentation"
        });

        [HttpGet("documentation")]
        public ActionResult Documentation() => Redirect("swagger/index.html");
    }
}
