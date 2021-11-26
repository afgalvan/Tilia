using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.SharedLib;

namespace Domain.Users.Repositories
{
    public interface IUsersRepository : IRepository<User, Guid>
    {
        public Task CreateRole(AccessRole accessRole, CancellationToken cancellation);
        public Task SetUserRole(User user, AccessRole accessRole, CancellationToken cancellation);
        public Task<IEnumerable<AccessRole>> GetRoles(CancellationToken cancellation);
        public Task<User> GetUserByEmailOrUsername(string usernameOrEmail, CancellationToken cancellation);
    }
}
