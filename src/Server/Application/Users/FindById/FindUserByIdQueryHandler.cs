using System.Threading;
using System.Threading.Tasks;
using Domain.Users;
using SharedLib.Domain.Bus.Query;

namespace Application.Users.FindById
{
    public class FindUserByIdQueryHandler : IQueryHandler<FindUserByIdQuery, User>
    {
        private readonly UserFinder _userFinder;

        public FindUserByIdQueryHandler(UserFinder userFinder)
        {
            _userFinder = userFinder;
        }

        public async Task<User> Handle(FindUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userFinder.FindUserById(request.Id, cancellationToken);
        }
    }
}
