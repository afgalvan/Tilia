using System.Threading;
using System.Threading.Tasks;
using Shared.Domain.Bus.Command;

namespace Application.Users.Create
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, string>
    {
        private readonly AccountCreator _accountCreator;

        public CreateUserCommandHandler(AccountCreator accountCreator)
        {
            _accountCreator = accountCreator;
        }

        public async Task<string> Handle(CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            return await _accountCreator.Create(request.Username, request.Email,
                request.Password, cancellationToken);
        }
    }
}
