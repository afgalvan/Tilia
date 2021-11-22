using System.Threading;
using System.Threading.Tasks;

namespace Domain.SharedLib
{
    public interface IRepository<TEntity, in TId> : IGetAll<TEntity>
    {
        public Task Save(TEntity entity, CancellationToken cancellation);
        public Task<TEntity> FindById(TId id, CancellationToken cancellation);
        public Task RemoveById(TId id, CancellationToken cancellation);
    }
}
