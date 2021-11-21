using System;
using Domain.Users;
using SharedLib.Domain.Bus.Query;

namespace Application.Users.FindById
{
    public class FindUserByIdQuery : IQuery<User>
    {
        public Guid Id { get; }

        public FindUserByIdQuery(string id)
        {
            Id = Guid.Parse(id);
        }
    }
}
