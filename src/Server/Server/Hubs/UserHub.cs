using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Users.Create;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.OpenApi.Models;
using Requests.Auth;
using Requests.Users;
using SignalRSwaggerGen.Attributes;

namespace Server.Hubs
{
    [SignalRHub("/hubs/users")]
    public class UserHub : Hub
    {
        private readonly IMediator            _mediator;
        private readonly IMapper              _mapper;

        public UserHub(IMediator mediator, IMapper mapper)
        {
            _mediator       = mediator;
            _mapper         = mapper;
        }

        [SignalRMethod("create")]
        [return: SignalRReturn(typeof(AccessToken), StatusCodes.Status201Created)]
        public async Task CreateUser([SignalRArg] CreateUserRequest createRequest)
        {
            var createUserCommand = _mapper.From(createRequest).AdaptToType<CreateUserCommand>();
            string authToken = await _mediator.Send(createUserCommand);
            await Clients.Caller.SendAsync("create", authToken);
        }

        [SignalRMethod("getAll", OperationType.Get)]
        [return: SignalRReturn(typeof(IEnumerable<UserResponse>))]
        public async Task GetAll([SignalRArg] AccessToken getAllRequest)
        {
            await Clients.Caller.SendAsync("getAll", getAllRequest);
        }
    }
}
