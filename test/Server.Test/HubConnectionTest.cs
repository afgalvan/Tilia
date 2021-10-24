using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using SharedLib.Users;

namespace Server.Test
{
    [TestFixture]
    public class HubConnectionTest
    {
        [Test]
        public void TestConnectionWithServer()
        {
            /*const string  url        = @"https://localhost:5001/hubs/users";
            HubConnection connection = new HubConnectionBuilder()
                .WithUrl(url)
                .AddMessagePackProtocol()
                .Build();
            var cts = new CancellationTokenSource();
            await connection.StartAsync(cts.Token);
            await connection.SendAsync("create", new CreateUserRequest
            {
                Name = "Andres"
            }, cts.Token);*/
        }
    }
}
