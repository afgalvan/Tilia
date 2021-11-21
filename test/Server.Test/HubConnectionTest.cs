using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Users;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Requests.Auth;
using Requests.Users;

namespace Server.Test
{
    [TestFixture]
    public class HubConnectionTest
    {
        [Test]
        public async Task TestConnectionWithServer()
        {
            const string url = @"https://localhost:5001/hubs/users";
            HubConnection connection = new HubConnectionBuilder()
                .WithUrl(url)
                .AddMessagePackProtocol()
                .Build();
            await connection.StartAsync();
            Console.WriteLine("Connected with hub!");

            connection.On<AccessToken>("create",
                users => Console.WriteLine("Create worked!"));
            connection.On<IEnumerable<User>>("getAll",
                users => users.ToList().ForEach(Console.WriteLine));

            var request = new CreateUserRequest
            {
                Username = "Brodel",
                Email    = "brodel@gmail.com",
                Password = "secret"
            };
            await connection.SendAsync("create", request);
            await connection.SendAsync("getAll");
            await Task.Delay(1000);
        }
    }
}
