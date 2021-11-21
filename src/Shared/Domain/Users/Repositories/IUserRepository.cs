using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.SharedLib;

namespace Domain.Users.Repositories
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        public Task CreateRole(AccessRole accessRole, CancellationToken cancellation);
        public Task SetUserRole(User user, AccessRole accessRole, CancellationToken cancellation);
        public Task<User> GetUserByEmailOrUsername(string usernameOrEmail, CancellationToken cancellation);
    }
}
