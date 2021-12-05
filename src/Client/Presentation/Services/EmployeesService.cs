using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Presentation.Services.Http.Connection;
using Requests.Employees;

namespace Presentation.Services
{
    public class EmployeesService
    {
        private readonly IRestComposer _restComposer;

        public EmployeesService(IRestComposer restComposer)
        {
            _restComposer = restComposer;
        }

        public async Task<IEnumerable<EmployeeResponse>> GetAllEmployees(
            CancellationToken cancellation)
        {
            const string endpoint = "/employees";
            return await _restComposer.GetAsync<IEnumerable<EmployeeResponse>>(endpoint, cancellation);
        }
    }
}
