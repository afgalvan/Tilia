using System.Collections.Generic;
using Requests.Users;
using SharedLib.Domain.Bus.Query;

namespace Application.Users.GetAll
{
    public class GetAllUsersQuery : IQuery<IEnumerable<UserResponse>>
    {
    }
}
