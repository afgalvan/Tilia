using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Locations;
using Domain.Locations.Repositories;
using Microsoft.EntityFrameworkCore;
using SharedLib.Persistence;

namespace Infrastructure.Persistence.Locations
{
    public class OracleLocationsRepository : ILocationsRepository
    {
        private readonly TiliaDbContext _dbContext;

        public OracleLocationsRepository(TiliaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Department>> GetAll(CancellationToken cancellation)
        {
            return await _dbContext.Departments.FromSqlRaw("SELECT * FROM \"departments\" ORDER BY \"name\"")
                .ToListAsync(cancellation);
        }

        public async Task<IEnumerable<City>> GetAllCitiesOf(string departmentId,
            CancellationToken cancellation)
        {
            return await _dbContext.Cities
                .FromSqlInterpolated($"SELECT * FROM \"cities\" WHERE \"department_id\" = {departmentId} ORDER BY \"name\"")
                .ToListAsync(cancellation);
        }
    }
}
