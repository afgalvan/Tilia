namespace Requests.Auth
{
    public class LoginUserRequest
    {
        public string UsernameOrEmail { get; set; }
        public string Password        { get; set; }

        public LoginUserRequest(string usernameOrEmail, string password)
        {
            UsernameOrEmail = usernameOrEmail;
            Password        = password;
        }

        public LoginUserRequest()
        {
        }
    }
}
