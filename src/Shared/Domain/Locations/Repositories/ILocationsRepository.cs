using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.SharedLib;

namespace Domain.Locations.Repositories
{
    public interface ILocationsRepository : IGetAll<Department>
    {
        public Task<IEnumerable<City>> GetAllCitiesOf(string departmentId,
            CancellationToken cancellation);
    }
}
