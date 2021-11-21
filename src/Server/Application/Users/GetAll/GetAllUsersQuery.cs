using System.Collections.Generic;
using Domain.Users;
using SharedLib.Domain.Bus.Query;

namespace Application.Users.GetAll
{
    public class GetAllUsersQuery : IQuery<IEnumerable<User>>
    {
    }
}
