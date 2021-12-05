using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.MedicalFiles;
using Domain.MedicalFiles.Repositories;
using Microsoft.EntityFrameworkCore;
using SharedLib.Persistence;

namespace Infrastructure.Persistence.MedicalFiles
{
    public class OracleAttentionHistoryRepository : IAttentionHistoryRepository
    {
        private readonly TiliaDbContext _dbContext;

        public OracleAttentionHistoryRepository(TiliaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<AttentionHistory>> GetAll(CancellationToken cancellation)
        {
            return await _dbContext.AttentionHistory.OrderBy(history => history.Date)
                .ToListAsync(cancellation);
        }

        public async Task Save(AttentionHistory entity, CancellationToken cancellation)
        {
            await _dbContext.AttentionHistory.AddAsync(entity, cancellation);
            await _dbContext.SaveChangesAsync(cancellation);
        }

        public Task<AttentionHistory> FindById(int id, CancellationToken cancellation)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveById(int id, CancellationToken cancellation)
        {
            throw new System.NotImplementedException();
        }

        public async Task Save(Guid appointmentId, CancellationToken cancellation)
        {
            int attendants = _dbContext.MedicalAppointments
                .Count(appointment => !appointment.IsActive);
            var history = new AttentionHistory(attendants, appointmentId);
            await Save(history, cancellation);
        }
    }
}
