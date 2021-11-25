using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Presentation.Services.Http.Exceptions;
using Requests.Responses;
using RestSharp;
using RestSharp.Authenticators;

namespace Presentation.Services.Http.Connection
{
    public class RestFetcher
    {
        private readonly IRestClient _client;

        public RestFetcher(IRestClient client)
        {
            _client = client;
        }

        public void SetAuthenticator(IAuthenticator authenticator)
        {
            _client.Authenticator = authenticator;
        }

        public async Task<TExpectedResponse> Fetch<TExpectedResponse>(IRestRequest request,
            Method method, CancellationToken cancellation)
        {
            IRestResponse<TExpectedResponse> response = await _client
                .ExecuteAsync<TExpectedResponse>(request, method, cancellation);
            RestoreToken();

            if (response.IsSuccessful)
            {
                return response.Data;
            }
            if (response.StatusCode == 0)
            {
                throw new ServerDownException("Sin conexión con el servidor.");
            }

            var error = JsonConvert.DeserializeObject<ErrorResponse>(response.Content);
            throw new HttpResponseException(error?.Message, response.StatusCode);
        }

        private void RestoreToken()
        {
            _client.Authenticator = null;
        }
    }
}
