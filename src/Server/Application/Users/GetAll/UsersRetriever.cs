using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Users;
using Domain.Users.Repositories;

namespace Application.Users.GetAll
{
    public class UsersRetriever
    {
        private readonly IUserRepository _repository;

        public UsersRetriever(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> GetAllUsers(CancellationToken cancellation)
        {
            return await _repository.GetAll(cancellation);
        }
    }
}
