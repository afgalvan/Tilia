#nullable enable
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Users;
using Domain.Users.Repositories;
using Microsoft.EntityFrameworkCore;
using SharedLib.Persistence;

namespace Infrastructure.Persistence.Users
{
    public class OracleUserRepository : IUserRepository
    {
        private readonly TiliaDbContext _dbContext;

        public OracleUserRepository(TiliaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Save(User entity, CancellationToken cancellation)
        {
            await _dbContext.Database.ExecuteSqlInterpolatedAsync(
                $"CALL pkg_users.create_user({entity.Id}, {entity.Name}, {entity.Password}, {entity.Email});",
                cancellation);
            await _dbContext.SaveChangesAsync(cancellation);
        }

        public async Task<IEnumerable<User>> GetAll(CancellationToken cancellation)
        {
            return await _dbContext.Users.FromSqlRaw("SELECT * FROM \"users\"")
                .ToListAsync(cancellation);
        }

        public Task<User?> GetById(Guid id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task Remove(User entity, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task CreateRole(AccessRole accessRole, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task SetUserRole(User user, AccessRole accessRole,
            CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByEmailOrUsername(string usernameOrEmail,
            CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task RemoveById(Guid id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
