using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Users;
using Shared.Infrastructure.Persistence;

namespace Infrastructure.Persistence.Users
{
    public class MySqlUserRepository : IUserRepository
    {
        private readonly TiliaDbContext _context;

        public MySqlUserRepository(TiliaDbContext context)
        {
            context.Database.EnsureCreated();
            _context = context;
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
