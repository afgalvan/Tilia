namespace Requests.Auth
{
    public class LoginResponse
    {
        public string UserId { get; set; }

        public LoginResponse(string userId)
        {
            UserId = userId;
        }

        public LoginResponse()
        {
        }
    }
}
