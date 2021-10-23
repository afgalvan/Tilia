using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Users.Create;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.OpenApi.Models;
using SharedLib.Auth;
using SharedLib.Users;
using SignalRSwaggerGen.Attributes;

namespace Server.Hubs
{
    [SignalRHub("/hubs/users")]
    public class UserHub : Hub
    {
        private readonly IMediator _mediator;
        private readonly IMapper   _mapper;

        public UserHub(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper   = mapper;
        }

        [SignalRMethod("create")]
        [return: SignalRReturn(typeof(AccessToken), StatusCodes.Status201Created)]
        public async Task Create([SignalRArg] CreateUserRequest createRequest,
            CancellationToken cancellation = default)
        {
            var createUserCommand = _mapper.From(createRequest).AdaptToType<CreateUserCommand>();
            await Clients.Caller.SendAsync("create", createRequest, cancellation);
        }

        [SignalRMethod("getAll", OperationType.Get)]
        [return: SignalRReturn(typeof(IEnumerable<UserResponse>))]
        public async Task GetAll([SignalRArg] AccessToken getAllRequest,
            CancellationToken cancellation = default)
        {
            await Clients.Caller.SendAsync("getAll", getAllRequest, cancellation);
        }
    }
}
