using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Users;
using Domain.Users.Repositories;

namespace Application.Users.FindById
{
    public class UserFinder
    {
        private readonly IUserRepository _userRepository;

        public UserFinder(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> FindUserById(Guid id, CancellationToken cancellation)
        {
            return await _userRepository.FindById(id, cancellation);
        }
    }
}
