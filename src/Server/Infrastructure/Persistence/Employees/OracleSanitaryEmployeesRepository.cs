using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Employees;
using Domain.Employees.Repositories;
using Microsoft.EntityFrameworkCore;
using SharedLib.Persistence;

namespace Infrastructure.Persistence.Employees
{
    public class OracleSanitaryEmployeesRepository : ISanitaryEmployeesRepository
    {
        private readonly TiliaDbContext _dbContext;

        public OracleSanitaryEmployeesRepository(TiliaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SanitaryEmployee>> GetAll(CancellationToken cancellation)
        {
            return await _dbContext.SanitaryEmployees
                .AsNoTracking()
                .Include(patient => patient.IdType)
                .Include(patient => patient.SanitaryRole)
                .ToListAsync(cancellation);
        }

        public async Task Save(SanitaryEmployee entity, CancellationToken cancellation)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            await _dbContext.SaveChangesAsync(cancellation);
        }

        public Task<SanitaryEmployee> FindById(string id, CancellationToken cancellation)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveById(string id, CancellationToken cancellation)
        {
            throw new System.NotImplementedException();
        }
    }
}
