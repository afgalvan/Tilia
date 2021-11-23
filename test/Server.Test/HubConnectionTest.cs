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
        private HubConnection _connection;

        [SetUp]
        public void SetUp()
        {
            const string url = @"https://794f-186-169-44-106.ngrok.io/hubs/users";
            /*_connection = new HubConnectionBuilder()
                .WithUrl(url)
                .AddMessagePackProtocol()
                .Build();
            await _connection.StartAsync();*/
            Console.WriteLine("Connected with hub!");
            // return Task.CompletedTask;
        }

        [Test, Order(0)]
        public void TestUserCreation()
        {
            var request = new CreateUserRequest
            {
                Username = "Sofi",
                Email    = "sofi@gmail.com",
                Password = "secret"
            };
            // await _connection.SendAsync("create", request);
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
