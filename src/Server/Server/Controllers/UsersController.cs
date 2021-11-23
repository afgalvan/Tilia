using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Users.FindById;
using Application.Users.GetAll;
using Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<User> response = await _mediator.Send(new GetAllUsersQuery());
            return Ok(response);
        }

        [Authorize]
        [HttpGet("find")]
        public async Task<IActionResult> FindById([FromQuery] string id)
        {
            User response = await _mediator.Send(new FindUserByIdQuery(id));
            return Ok(response);
        }
    }
}
