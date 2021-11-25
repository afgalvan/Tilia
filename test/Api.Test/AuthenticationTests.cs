using NUnit.Framework;
using Requests.Auth;

namespace Api.Test
{
    public class AuthenticationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LoginTest()
        {
            var loginRequest = new LoginUserRequest
            {
                UsernameOrEmail = "afgalvan",
                Password        = "secret"
            };

            /*const string host   = "https://e44a-186-169-44-106.ngrok.io";
            var          client = new RestClient(host);
            var request = new RestRequest("/auth/sign-in")
                .AddJsonBody(loginRequest);

            var response = await client.ExecuteAsync<AuthenticationResponse>(request, Method.POST);
            if (!response.IsSuccessful)
            {
                Console.WriteLine(JsonConvert.DeserializeObject<ErrorResponse>(response.Content).Message);
            }*/
        }
    }
}
