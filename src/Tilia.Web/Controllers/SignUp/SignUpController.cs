using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Users.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tilia.Web.Controllers.Shared;

namespace Tilia.Web.Controllers.SignUp
{
    [Route("api/auth")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly IMediator                 _mediator;
        private readonly ILogger<SignUpController> _logger;

        public SignUpController(IMediator mediator, ILogger<SignUpController> logger)
        {
            _mediator = mediator;
            _logger   = logger;
        }

        [HttpPost("signUp")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(AuthenticationResponse), StatusCodes.Status201Created)]
        public async Task<ActionResult> SignUp([FromBody] SignUpRequest request,
            CancellationToken cancellationToken)
        {
            var command = new CreateUserCommand(request.Username, request.Email, request.Password);
            try
            {
                string token = await _mediator.Send(command, cancellationToken);
                _logger.LogInformation("New token retrieved");
                return Created("", new AuthenticationResponse(token));
            }
            catch (ArgumentNullException)
            {
                ModelState.AddModelError("RepeatedUser", "Duplicated username or email");
                return BadRequest(ModelState);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.StackTrace);
                return BadRequest();
            }
        }
    }
}
