using System;
using System.Net;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Extensions.Logging;

namespace Presentation.Controllers
{
    public class UserHubConnection : HubConnection
    {
        public UserHubConnection(IConnectionFactory connectionFactory, IHubProtocol protocol,
            EndPoint endPoint, IServiceProvider serviceProvider, ILoggerFactory loggerFactory,
            IRetryPolicy reconnectPolicy) : base(connectionFactory, protocol, endPoint,
            serviceProvider, loggerFactory, reconnectPolicy)
        {
        }

        public UserHubConnection(IConnectionFactory connectionFactory, IHubProtocol protocol,
            EndPoint endPoint, IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
            : base(connectionFactory, protocol, endPoint, serviceProvider, loggerFactory)
        {
        }
    }
}
