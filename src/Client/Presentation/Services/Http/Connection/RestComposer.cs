using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace Presentation.Services.Http.Connection
{
    public class RestComposer : IRestComposer
    {
        private readonly RestFetcher _restFetcher;

        public RestComposer(RestFetcher restFetcher)
        {
            _restFetcher = restFetcher;
        }

        public IRestComposer WithAuth(string token)
        {
            _restFetcher.SetAuthenticator(new JwtAuthenticator(token));
            return this;
        }

        public async Task<TExpectedResponse> Post<TExpectedResponse>(IRestRequest request,
            CancellationToken cancellation)
        {
            return await _restFetcher.Fetch<TExpectedResponse>(request, Method.POST,
                cancellation);
        }

        public async Task<TExpectedResponse> Put<TExpectedResponse>(IRestRequest request,
            CancellationToken cancellation)
        {
            return await _restFetcher.Fetch<TExpectedResponse>(request, Method.PUT,
                cancellation);
        }

        public async Task<TExpectedResponse> Patch<TExpectedResponse>(IRestRequest request,
            CancellationToken cancellation)
        {
            return await _restFetcher.Fetch<TExpectedResponse>(request, Method.PATCH,
                cancellation);
        }

        public async Task<TExpectedResponse> Delete<TExpectedResponse>(string endpoint,
            CancellationToken cancellation)
        {
            var request = new RestRequest(endpoint);
            return await _restFetcher.Fetch<TExpectedResponse>(request, Method.GET,
                cancellation);
        }

        public async Task<TExpectedResponse> GetAsync<TExpectedResponse>(string endpoint,
            CancellationToken cancellation)
        {
            var request = new RestRequest(endpoint, DataFormat.Json);
            return await _restFetcher.Fetch<TExpectedResponse>(request, Method.GET,
                cancellation);
        }
    }
}
