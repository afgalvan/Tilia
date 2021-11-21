using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.Controllers.Connection
{
    public class ServerConnection
    {
        private readonly ConnectionConfig     _config;
        private readonly HubConnectionBuilder _builder;

        public ServerConnection(ConnectionConfig config, HubConnectionBuilder builder)
        {
            _config  = config;
            _builder = builder;
        }

        public HubConnection ConnectionWith(string hub)
        {
            return _builder.WithUrl($"{_config.Host}/hubs/{hub}")
                .AddMessagePackProtocol()
                .Build();
        }
    }
}
