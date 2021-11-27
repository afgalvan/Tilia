using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Employees;
using Domain.Employees.Repositories;
using Microsoft.EntityFrameworkCore;
using SharedLib.Persistence;

namespace Infrastructure.Persistence.Employees
{
    public class OracleSanitaryRolesRepository : ISanitaryRolesRepository
    {
        private readonly TiliaDbContext _dbContext;

        public OracleSanitaryRolesRepository(TiliaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SanitaryRole>> GetAll(CancellationToken cancellation)
        {
            return await _dbContext.SanitaryRoles.ToListAsync(cancellation);
        }

        public async Task Save(SanitaryRole entity, CancellationToken cancellation)
        {
            await _dbContext.SanitaryRoles.AddAsync(entity, cancellation);
            await _dbContext.SaveChangesAsync(cancellation);
        }

        public async Task<SanitaryRole> FindById(Guid id, CancellationToken cancellation)
        {
            return await _dbContext.SanitaryRoles.FirstOrDefaultAsync(role => role.Id == id,
                cancellation);
        }

        public async Task RemoveById(Guid id, CancellationToken cancellation)
        {
            _dbContext.SanitaryRoles.Remove(await FindById(id, cancellation));

        }
    }
}
