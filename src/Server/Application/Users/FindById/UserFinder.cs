using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Users;
using Domain.Users.Repositories;

namespace Application.Users.FindById
{
    public class UserFinder
    {
        private readonly IUsersRepository _usersRepository;

        public UserFinder(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<User> FindUserById(Guid id, CancellationToken cancellation)
        {
            return await _usersRepository.FindById(id, cancellation);
        }
    }
}
