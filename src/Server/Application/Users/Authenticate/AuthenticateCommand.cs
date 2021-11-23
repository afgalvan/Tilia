using SharedLib.Domain.Bus.Command;

namespace Application.Users.Authenticate
{
    public class AuthenticateCommand : ICommand<string>
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }

        public AuthenticateCommand(string usernameOrEmail, string password)
        {
            UsernameOrEmail = usernameOrEmail;
            Password = password;
        }
    }
}
