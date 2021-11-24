using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Presentation.Settings;
using Requests.Responses;
using RestSharp;

namespace Presentation.Services.Http.Utils
{
    public class RestComposer
    {
        private readonly RestClient _client;

        public RestComposer(RestClient client)
        {
            _client = client;
        }

        private async Task<TExpectedResponse> Execute<TExpectedResponse>(IRestRequest request,
            Method method, CancellationToken cancellation)
        {
            IRestResponse<TExpectedResponse> response =
                await _client.ExecuteAsync<TExpectedResponse>(request, method, cancellation);

            if (response.IsSuccessful) return response.Data;
            if ((int)response.StatusCode >= 500)
                throw new ServerDownException("Servidor sin conexión.");
            var error = JsonConvert.DeserializeObject<ErrorResponse>(response.Content);
            throw new HttpResponseException(error?.Message);
        }

        public async Task<TExpectedResponse> Post<TExpectedResponse>(IRestRequest request,
            CancellationToken cancellation)
        {
            return await Execute<TExpectedResponse>(request, Method.POST, cancellation);
        }

        public async Task<TExpectedResponse> Get<TExpectedResponse>(string endpoint,
            CancellationToken cancellation)
        {
            var request = new RestRequest(endpoint, DataFormat.Json);
            return await Execute<TExpectedResponse>(request, Method.GET, cancellation);
        }

        public static ConnectionConfig FetchConnectionConfig(string url)
        {
            var client = new RestClient(url)
            {
                ThrowOnAnyError = true
            };
            var request = new RestRequest(Method.GET);
            return JsonConvert.DeserializeObject<ConnectionConfig>(client.Get(request)
                .Content);
        }
    }
}
