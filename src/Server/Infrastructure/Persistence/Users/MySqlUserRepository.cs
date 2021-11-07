using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Persistence;
using Domain.Users;
using Domain.Users.Repositories;

namespace Infrastructure.Persistence.Users
{
    public class MySqlUserRepository : IUserRepository
    {
        private readonly TiliaDbContext _dbContext;

        public MySqlUserRepository(TiliaDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            _dbContext = dbContext;
        }

        public Task<User> Save(User entity, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll(CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(Guid id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task Remove(User entity, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByEmailOrUsername(string usernameOrEmail, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task RemoveById(Guid id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
