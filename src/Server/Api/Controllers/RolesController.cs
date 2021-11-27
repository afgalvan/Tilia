using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Employees;
using Domain.Employees.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly ISanitaryRolesRepository _sanitaryRoles;

        public RolesController(ISanitaryRolesRepository sanitaryRoles)
        {
            _sanitaryRoles = sanitaryRoles;
        }

        [HttpPost("sanitary")]
        public async Task<IActionResult> AddSanitaryRole([FromRoute] string roleName,
            CancellationToken cancellation)
        {
            await _sanitaryRoles.Save(new SanitaryRole(roleName), cancellation);
            return Ok();
        }

        [HttpGet("sanitary")]
        [ProducesResponseType(typeof(IEnumerable<SanitaryRole>), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddSanitaryRole(CancellationToken cancellation)
        {
            return Ok(await _sanitaryRoles.GetAll(cancellation));
        }
    }
}
