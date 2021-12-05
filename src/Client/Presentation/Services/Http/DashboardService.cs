using Presentation.Services.Http.Connection;
using Requests.Dashboard;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Services.Http
{
    public class DashboardService
    {
        private readonly IRestComposer _restComposer;

        public DashboardService(IRestComposer restComposer)
        {
            _restComposer = restComposer;
        }

        public async Task<DashboardInformationResponse> GetStatistics(CancellationToken cancellation)
        {
            const string endpoint = "/dashboard";
            return await _restComposer.GetAsync<DashboardInformationResponse>(endpoint, cancellation);
        }
    }
}
