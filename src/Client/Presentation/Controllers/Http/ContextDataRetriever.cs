using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Locations;
using Domain.People;
using Presentation.Filters;
using Presentation.Settings;
using RestWrapper;

namespace Presentation.Controllers.Http
{
    public class ContextDataRetriever
    {
        private readonly ConnectionConfig _config;

        public ContextDataRetriever(ConnectionConfig config)
        {
            _config = config;
        }

        [HandleUnconnected]
        public async Task<IEnumerable> GetIdTypes(CancellationToken cancellation)
        {
            return (await new RestRequest($"{_config.Host}/id-types")
                .SendAsync(cancellation)).DataFromJson<IEnumerable<IdType>>();
        }

        [HandleUnconnected]
        public async Task<IEnumerable> GetDepartments(CancellationToken cancellation)
        {
            return (await new RestRequest($"{_config.Host}/locations/departments")
                    .SendAsync(cancellation)).DataFromJson<IEnumerable<Department>>();
        }

        [HandleUnconnected]
        public async Task<IEnumerable> GetCities(string departmentId, CancellationToken cancellation)
        {
            return (await new RestRequest($"{_config.Host}/locations/cities?departmentId={departmentId}")
                .SendAsync(cancellation)).DataFromJson<IEnumerable<City>>();
        }
    }
}
