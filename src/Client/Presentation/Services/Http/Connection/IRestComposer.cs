using System.Threading;
using System.Threading.Tasks;
using RestSharp;

namespace Presentation.Services.Http.Connection
{
    public interface IRestComposer
    {
        IRestComposer WithAuth(string token);

        Task<TExpectedResponse> Post<TExpectedResponse>(IRestRequest request,
            CancellationToken cancellation);

        Task<TExpectedResponse> Put<TExpectedResponse>(IRestRequest request,
            CancellationToken cancellation);

        Task<TExpectedResponse> Patch<TExpectedResponse>(IRestRequest request,
            CancellationToken cancellation);

        Task<TExpectedResponse> Delete<TExpectedResponse>(string endpoint,
            CancellationToken cancellation);

        Task<TExpectedResponse> GetAsync<TExpectedResponse>(string endpoint,
            CancellationToken cancellation);
    }
}
