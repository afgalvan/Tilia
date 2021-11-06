using System.Threading;
using System.Threading.Tasks;
using SharedLib.Domain.Bus.Command;

namespace Application.Users.Create
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, string>
    {
        private readonly UserCreator _userCreator;

        public CreateUserCommandHandler(UserCreator userCreator)
        {
            _userCreator = userCreator;
        }

        public async Task<string> Handle(CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            return await _userCreator.Create(request.Username, request.Email,
                request.Password, cancellationToken);
        }
    }
}
