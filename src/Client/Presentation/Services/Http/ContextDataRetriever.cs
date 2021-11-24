using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Locations;
using Domain.People;
using Presentation.Filters;
using Presentation.Services.Http.Utils;

namespace Presentation.Services.Http
{
    public class ContextDataRetriever
    {
        private readonly RestComposer _restComposer;

        public ContextDataRetriever(RestComposer restComposer)
        {
            _restComposer = restComposer;
        }

        [HandleServerDown]
        public async Task<IEnumerable> GetIdTypes(CancellationToken cancellation)
        {
            const string endpoint = "/id-types";
            return await _restComposer.Get<IEnumerable<IdType>>(endpoint, cancellation);
        }

        [HandleServerDown]
        public async Task<IEnumerable> GetDepartments(CancellationToken cancellation)
        {
            const string endpoint = "/locations/departments";
            return await _restComposer.Get<IEnumerable<Department>>(endpoint, cancellation);
        }

        [HandleServerDown]
        public async Task<IEnumerable> GetCities(string departmentId,
            CancellationToken cancellation)
        {
            var endpoint = $"/locations/cities?departmentId={departmentId}";
            return await _restComposer.Get<IEnumerable<City>>(endpoint, cancellation);
        }
    }
}
