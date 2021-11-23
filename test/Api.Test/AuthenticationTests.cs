using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using Requests.Auth;
using RestWrapper;

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

            const string host = "https://e44a-186-169-44-106.ngrok.io";
            var request = new RestRequest($"{host}/auth/sign-in", HttpMethod.POST,
                "application/json");
            RestResponse response =
                await request.SendAsync(JsonConvert.SerializeObject(loginRequest));
            if (response.StatusCode == 200)
            {
                string token = response.DataFromJson<AuthenticationResponse>().Token;
                Console.WriteLine($"Token: {token}");
            }
        }
    }
}
