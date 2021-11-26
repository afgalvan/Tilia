#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Users;
using Domain.Users.Repositories;
using Microsoft.EntityFrameworkCore;
using SharedLib.Persistence;

namespace Infrastructure.Persistence.Users
{
    public class OracleUsersRepository : IUsersRepository
    {
        private readonly TiliaDbContext _dbContext;

        public OracleUsersRepository(TiliaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Save(User entity, CancellationToken cancellation)
        {
            await _dbContext.Database.ExecuteSqlInterpolatedAsync(
                $"INSERT INTO \"users\" (\"id\", \"name\", \"password\", \"email\") VALUES ({entity.Id}, {entity.Name}, {entity.Password}, {entity.Email});",
                cancellation);
            await _dbContext.SaveChangesAsync(cancellation);
        }

        public async Task<IEnumerable<User>> GetAll(CancellationToken cancellation)
        {
            return await _dbContext.Users.FromSqlRaw("SELECT * FROM \"users\"")
                .ToListAsync(cancellation);
        }

        public async Task<User?> FindById(Guid id, CancellationToken cancellation)
        {
            return await _dbContext.Users
                .FromSqlInterpolated($"SELECT * FROM \"users\" WHERE \"id\" = {id}")
                .SingleAsync(cancellation);
        }

        public async Task CreateRole(AccessRole accessRole, CancellationToken cancellation)
        {
            await _dbContext.Database
                .ExecuteSqlInterpolatedAsync(
                    $"INSERT INTO \"access_roles\" (\"id\", \"name\") VALUES ({accessRole.Id}, {accessRole.Name})",
                    cancellation
                );
            await _dbContext.SaveChangesAsync(cancellation);
        }

        public async Task SetUserRole(User user, AccessRole accessRole,
            CancellationToken cancellation)
        {
            await _dbContext.Database
                .ExecuteSqlInterpolatedAsync(
                    $"UPDATE \"users\" SET \"access_role_id\" = {accessRole.Id} WHERE \"id\" = {user.Id}",
                    cancellation
                );
            await _dbContext.SaveChangesAsync(cancellation);
        }

        public async Task<IEnumerable<AccessRole>> GetRoles(CancellationToken cancellation)
        {
            return await _dbContext.AccessRoles
                .FromSqlRaw("SELECT * FROM \"acess_roles\"")
                .ToListAsync(cancellation);
        }

#nullable enable
        public async Task<User?> GetUserByEmailOrUsername(string usernameOrEmail,
            CancellationToken cancellation)
        {
            IQueryable<User>? queryResult = _dbContext.Users
                .FromSqlInterpolated(
                    $"SELECT * FROM \"users\" WHERE \"name\" = {usernameOrEmail} OR \"email\" = {usernameOrEmail}"
                );

            return queryResult.Any() ? await queryResult.SingleAsync(cancellation) : null;
        }

        public Task RemoveById(Guid id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
