using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.SharedLib
{
    public interface IRepository<TEntity, in TId>
    {
        public Task Save(TEntity entity, CancellationToken cancellation);
        public Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellation);
        public Task<TEntity> GetById(TId id, CancellationToken cancellation);
        public Task Remove(TEntity entity, CancellationToken cancellation);
    }
}
