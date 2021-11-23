using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using Requests.Users;
using SharedLib.Domain.Bus.Query;

namespace Application.Users.GetAll
{
    public class GetAllUsersQueryHandler : IQueryHandler<GetAllUsersQuery, IEnumerable<UserResponse>>
    {
        private readonly UsersRetriever _usersRetriever;

        public GetAllUsersQueryHandler(UsersRetriever usersRetriever)
        {
            _usersRetriever = usersRetriever;
        }

        public async Task<IEnumerable<UserResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return (await _usersRetriever.GetAllUsers(cancellationToken))
                .Adapt<IEnumerable<UserResponse>>();
        }
    }
}
