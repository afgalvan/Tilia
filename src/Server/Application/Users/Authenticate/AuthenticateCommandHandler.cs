using System.Threading;
using System.Threading.Tasks;
using SharedLib.Domain.Bus.Command;

namespace Application.Users.Authenticate
{
    public class AuthenticateCommandHandler : ICommandHandler<AuthenticateCommand, string>
    {
        private readonly UserAuthenticator _authenticator;

        public AuthenticateCommandHandler(UserAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }

        public async Task<string> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            return await _authenticator.Authenticate(request.UsernameOrEmail, request.Password, cancellationToken);
        }
    }
}
