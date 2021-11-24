using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using Presentation.Services.Http.Utils;
using Requests.Auth;
using RestSharp;

namespace Presentation.Services.Http
{
    public class AuthenticationService
    {
        private readonly RestComposer _restComposer;

        public AuthenticationService(RestComposer restComposer)
        {
            _restComposer = restComposer;
        }

        public async Task<AuthenticationResponse> SendLoginRequest(
            LoginUserRequest loginRequest,
            CancellationToken cancellation)
        {
            IRestRequest request = new RestRequest("/auth/users").AddJsonBody(loginRequest);
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
