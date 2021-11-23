namespace Requests.Auth
{
    public class LoginUserRequest
    {
        public string UsernameOrEmail { get; set; }
        public string Password        { get; set; }
    }
}
