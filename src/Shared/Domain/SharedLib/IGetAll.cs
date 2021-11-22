using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.SharedLib
{
    public interface IGetAll<TEntity>
    {
        public Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellation);
    }
}
