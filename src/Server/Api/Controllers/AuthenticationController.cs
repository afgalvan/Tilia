using System.Security.Authentication;
using System.Threading.Tasks;
using Application.Users.Authenticate;
using Application.Users.Create;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using Requests.Auth;
using Requests.Responses;
using Requests.Users;

namespace Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper   _mapper;

        public AuthenticationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper   = mapper;
        }

        [HttpPost("sign-up")]
        [ProducesResponseType(typeof(AuthenticationResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest createRequest)
        {
            var createUserCommand =
                _mapper.From(createRequest).AdaptToType<CreateUserCommand>();

            try
            {
                string token = await _mediator.Send(createUserCommand);
                return Created("", new AuthenticationResponse(token));
            }
            catch (OracleException)
            {
                return BadRequest(new { Message = "Nombre de usuario o email repetido" });
            }
        }

        [HttpPost("sign-in")]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(AuthenticationResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> Authenticate([FromBody] LoginUserRequest request)
        {
            var authenticateCommand = _mapper.From(request).AdaptToType<AuthenticateCommand>();
            try
            {
                string token = await _mediator.Send(authenticateCommand);
                return Ok(new AuthenticationResponse(token));
            }
            catch (AuthenticationException e)
            {
                return BadRequest(new { e.Message });
            }
        }
    }
}
