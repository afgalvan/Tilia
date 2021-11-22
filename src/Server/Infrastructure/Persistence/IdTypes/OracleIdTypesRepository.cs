using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.People;
using Domain.People.Repositories;
using Microsoft.EntityFrameworkCore;
using SharedLib.Persistence;

namespace Infrastructure.Persistence.IdTypes
{
    public class OracleIdTypesRepository : IIdTypesRepository
    {
        private readonly TiliaDbContext _dbContext;

        public OracleIdTypesRepository(TiliaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<IdType>> GetAll(CancellationToken cancellation)
        {
            return await _dbContext.IdTypes.FromSqlRaw("SELECT * FROM \"id_types\"")
                .ToListAsync(cancellation);
        }
    }
}
