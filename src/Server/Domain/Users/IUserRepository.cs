﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Shared;

namespace Domain.Users
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        public Task<User> GetUserByEmailOrUsername(string usernameOrEmail, CancellationToken cancellation);
        public Task RemoveById(Guid id, CancellationToken cancellation);
    }
}