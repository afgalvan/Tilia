using System.Net;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Presentation.Settings;
using Requests.Auth;
using Requests.Responses;
using RestWrapper;

namespace Presentation.Services.Http
{
    public class AuthenticationService
    {
        private readonly ConnectionConfig _config;
        private const    string           ContentType = "application/json";

        public AuthenticationService(ConnectionConfig config)
        {
            _config = config;
        }

        public async Task<string> LoginUser(LoginUserRequest loginRequest,
            CancellationToken cancellation)
        {
            RestResponse response = await SendLoginRequest(loginRequest, cancellation);

            if (response.StatusCode == (int)HttpStatusCode.OK)
            {
                return response.DataFromJson<AuthenticationResponse>().Token;
            }

            string message = response.DataFromJson<ErrorResponse>().Message;
            throw new AuthenticationException(message);
        }

        private async Task<RestResponse> SendLoginRequest(LoginUserRequest loginRequest,
            CancellationToken cancellation)
        {
            var    endpoint = $"{_config.Host}/auth/sign-in";
            var    request  = new RestRequest(endpoint, HttpMethod.POST, ContentType);
            string body     = JsonConvert.SerializeObject(loginRequest);
            return await request.SendAsync(body, cancellation);
        }
    }
}
