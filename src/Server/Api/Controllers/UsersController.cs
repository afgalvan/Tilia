using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Users.FindById;
using Application.Users.GetAll;
using Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Requests.Users;

namespace Api.Controllers
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

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<UserResponse> response = await _mediator.Send(new GetAllUsersQuery());
            return Ok(response);
        }

        [HttpGet("find")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> FindById([FromQuery] string id)
        {
            User response = await _mediator.Send(new FindUserByIdQuery(id));
            return Ok(response);
        }
    }
}
