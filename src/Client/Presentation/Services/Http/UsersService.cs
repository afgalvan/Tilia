using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Presentation.Filters;
using Presentation.Services.Http.Connection;
using Requests.Auth;
using Requests.Users;
using RestSharp;

namespace Presentation.Services.Http
{
    public class UsersService
    {
        private readonly IRestComposer _restComposer;

        public UsersService(IRestComposer restComposer)
        {
            _restComposer = restComposer;
        }

        [WithJwtToken]
        public async Task<IEnumerable<UserResponse>> GetUsers(CancellationToken cancellation,
            string token = default)
        {
            const string endpoint = "/users";
            return await _restComposer.WithAuth(token)
                .GetAsync<IEnumerable<UserResponse>>(endpoint, cancellation);
        }

        [WithJwtToken]
        public async Task<UserResponse> GetUserById(string userId,
            CancellationToken cancellation, string token = default)
        {
            var endpoint = $"/users/find?id={userId}";
            return await _restComposer.WithAuth(token)
                .GetAsync<UserResponse>(endpoint, cancellation);
        }

        [WithJwtToken]
        public async Task CreateUser(string username,
            string email, string password, CancellationToken cancellation,
            string token = default)
        {
            const string endpoint = "/auth/sign-up";
            var userRequest = new CreateUserRequest
            {
                Username = username,
                Email    = email,
                Password = password
            };
            IRestRequest request = new RestRequest(endpoint).AddJsonBody(userRequest);
            // Put Auth
            await _restComposer.Post<AuthenticationResponse>(request, cancellation);
        }
    }
}
