using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Users.Authenticate;
using Application.Users.Create;
using Application.Users.FindById;
using Application.Users.GetAll;
using Domain.Users;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Requests.Auth;
using Requests.Users;
using SignalRSwaggerGen.Attributes;

namespace Server.Hubs
{
    [SignalRHub("/hubs/users")]
    public class UserHub : Hub
    {
        private readonly IMediator        _mediator;
        private readonly IMapper          _mapper;
        private readonly ILogger<UserHub> _logger;

        public UserHub(IMediator mediator, IMapper mapper, ILogger<UserHub> logger)
        {
            _mediator = mediator;
            _mapper   = mapper;
            _logger   = logger;
        }

        [SignalRMethod("create")]
        [return: SignalRReturn(typeof(AccessToken), StatusCodes.Status201Created)]
        public async Task Create([SignalRArg] CreateUserRequest createRequest)
        {
            var createUserCommand =
                _mapper.From(createRequest).AdaptToType<CreateUserCommand>();
            string authToken = await _mediator.Send(createUserCommand);

            await Clients.All.SendAsync("create", new AccessToken(authToken));
        }

        [SignalRMethod("getAll", OperationType.Get)]
        [return: SignalRReturn(typeof(IEnumerable<User>))]
        public async Task GetAll()
        {
            IEnumerable<User> response = await _mediator.Send(new GetAllUsersQuery());
            await Clients.All.SendAsync("getAll", response);
        }

        [SignalRMethod("findById", OperationType.Get)]
        public async Task FindById([SignalRArg] string id)
        {
            User response = await _mediator.Send(new FindUserByIdQuery(id));
            await Clients.All.SendAsync("findById", response);
        }

        [SignalRMethod("authenticate", OperationType.Get)]
        [return: SignalRReturn(typeof(LoginResponse))]
        public async Task Authenticate([SignalRArg] LoginUserRequest request)
        {
            _logger.LogInformation("authenticating...");
            var authenticateCommand = _mapper.From(request).AdaptToType<AuthenticateCommand>();
            string userId = await _mediator.Send(authenticateCommand);
            await Clients.Caller.SendAsync("authenticate", new LoginResponse(userId));
        }
    }
}
