using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Locations;
using Domain.People;
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

        public async Task<IEnumerable<IdType>> GetIdTypes(CancellationToken cancellation)
        {
            return (await new RestRequest($"{_config.Host}/id-types").SendAsync(cancellation))
                .DataFromJson<IEnumerable<IdType>>();
        }

        public async Task<IEnumerable<City>> GetCities(CancellationToken cancellation)
        {
            return (await new RestRequest($"{_config.Host}/cities").SendAsync(cancellation))
                .DataFromJson<IEnumerable<City>>();
        }
    }
}
