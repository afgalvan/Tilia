using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Settings;

namespace Presentation.Services.Hubs.Connection
{
    public class SocketConnection
    {
        private readonly ConnectionConfig     _config;
        private readonly HubConnectionBuilder _builder;

        public SocketConnection(ConnectionConfig config, HubConnectionBuilder builder)
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
