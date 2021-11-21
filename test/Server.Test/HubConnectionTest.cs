using System;
using System.Threading.Tasks;
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
        // private HubConnection _connection;

        [SetUp]
        public Task SetUp()
        {
            const string url = @"https://localhost:5001/hubs/users";
            /*_connection = new HubConnectionBuilder()
                .WithUrl(url)
                .AddMessagePackProtocol()
                .Build();
            await _connection.StartAsync();
            Console.WriteLine("Connected with hub!");*/
            return Task.CompletedTask;
        }

        [Test, Order(0)]
        public async Task TestUserCreation()
        {
            var request = new CreateUserRequest
            {
                Username = "Sofi",
                Email    = "sofi@gmail.com",
                Password = "secret"
            };
            // await _connection.SendAsync("create", request);
            // await connection.SendAsync("findById", "a1d1767c-6487-4b21-a81c-bbf10f8998ac");
            // await connection.SendAsync("getAll");
        }

        [Test, Order(1)]
        public void TestUserLogin()
        {
            /*_connection.On<LoginResponse>("authenticate",
                response =>
                {
                    Console.WriteLine("Authentication call worked");
                    Console.WriteLine(response.UserId);
                }
            );
            var requestA = new LoginUserRequest
            {
                Username = "Sofi",
                Password = "secret"
            };
            await _connection.SendAsync("authenticate", requestA);
            await Task.Delay(10_000);*/
        }
    }
}
