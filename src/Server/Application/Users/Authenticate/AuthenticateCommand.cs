using SharedLib.Domain.Bus.Command;

namespace Application.Users.Authenticate
{
    public class AuthenticateCommand : ICommand<string>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public AuthenticateCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
