using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SharedLib;
using SignalRSwaggerGen.Attributes;

namespace Server.Hubs
{
    [SignalRHub("/hubs/users")]
    public class UserHub : Hub
    {
        [SignalRMethod("send")]
        public async Task Send([SignalRArg] CreateUserRequest data, CancellationToken cancellationToken = default)
        {
            await Clients.Others.SendAsync("send", data, cancellationToken);
        }
    }
}
