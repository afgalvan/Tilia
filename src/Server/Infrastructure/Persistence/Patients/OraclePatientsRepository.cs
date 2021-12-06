using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Patients;
using Domain.Patients.Repositories;
using Microsoft.EntityFrameworkCore;
using SharedLib.Persistence;

namespace Infrastructure.Persistence.Patients
{
    public class OraclePatientsRepository : IPatientsRepository
    {
        private readonly TiliaDbContext _dbContext;

        public OraclePatientsRepository(TiliaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Patient>> GetAll(CancellationToken cancellation)
        {
            return await _dbContext.Patients
                .AsNoTracking()
                .Include(patient => patient.IdType)
                .ToListAsync(cancellation);
        }

        public async Task Save(Patient entity, CancellationToken cancellation)
        {
            _dbContext.Entry(entity).State             = EntityState.Added;
            _dbContext.Entry(entity.ContactData).State = EntityState.Added;
            _dbContext.Entry(entity.SportsData).State  = EntityState.Added;
            await _dbContext.SaveChangesAsync(cancellation);
        }

        public async Task<Patient> FindById(string id, CancellationToken cancellation)
        {
            return await _dbContext.Patients.AsNoTracking()
                .Include(patient => patient.IdType)
                .Include(patient => patient.City)
                .Include(patient => patient.ContactData.LivingCity)
                .FirstOrDefaultAsync(patient => patient.PersonId == id, cancellation);
        }

        public async Task RemoveById(string id, CancellationToken cancellation)
        {
            Patient found =
                await _dbContext.Patients.FirstOrDefaultAsync(
                    patient => patient.PersonId == id, cancellation
                );
            _dbContext.Remove(found);
            await _dbContext.SaveChangesAsync(cancellation);
        }

        public async Task<int> CountPatients(CancellationToken cancellation)
        {
            return await _dbContext.Patients.CountAsync(cancellation);
        }
    }
}
