using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using Presentation.Services.Http.Connection;
using Presentation.Services.Http.Exceptions;
using Requests.Auth;
using RestSharp;

namespace Presentation.Services.Http
{
    public class AuthenticationService
    {
        private readonly IRestComposer _restComposer;

        public AuthenticationService(IRestComposer restComposer)
        {
            _restComposer = restComposer;
        }

        public async Task<AuthenticationResponse> SendLoginRequest(
            string usernameOrEmail, string password,
            CancellationToken cancellation)
        {
            var          loginRequest = new LoginUserRequest(usernameOrEmail, password);
            IRestRequest request = new RestRequest("/auth/sign-in").AddJsonBody(loginRequest);
            try
            {
                return await _restComposer.Post<AuthenticationResponse>(request, cancellation);
            }
            catch (HttpResponseException e)
            {
                throw new AuthenticationException(e.Message);
            }
        }
    }
}
