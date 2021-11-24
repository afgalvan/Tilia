using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using Requests.Auth;
using Requests.Responses;
using RestSharp;

namespace Api.Test
{
    public class AuthenticationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task LoginTest()
        {
            var loginRequest = new LoginUserRequest
            {
                UsernameOrEmail = "afgalvan",
                Password        = "secret"
            };

            const string host   = "https://e44a-186-169-44-106.ngrok.io";
            var          client = new RestClient(host);
            var request = new RestRequest("/auth/sign-in")
                .AddJsonBody(loginRequest);

            var response = await client.ExecuteAsync<AuthenticationResponse>(request, Method.POST);
            if (!response.IsSuccessful)
            {
                Console.WriteLine(JsonConvert.DeserializeObject<ErrorResponse>(response.Content).Message);
            }

            var client2  = new RestClient($"https://raw.githubusercontent.com/afgalvan/Tilia.Tunnel/main/tunnels.json");
            var request2 = new RestRequest(Method.GET);
            Console.WriteLine(client2.Get(request2).Content);
        }
    }
}
