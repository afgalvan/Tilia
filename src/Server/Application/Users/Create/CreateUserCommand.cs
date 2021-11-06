using SharedLib.Domain.Bus.Command;

namespace Application.Users.Create
{
    public class CreateUserCommand : ICommand<string>
    {
        public string Username { get; set; }
        public string Email    { get; set; }
        public string Password { get; set; }

        public CreateUserCommand(string username, string email, string password)
        {
            Username = username;
            Email    = email;
            Password = password;
        }
    }
}
