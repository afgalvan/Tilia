namespace Tilia.Web.Controllers.Shared
{
    public class AuthenticationResponse
    {
        public string Token { get; init; }

        public AuthenticationResponse(string token)
        {
            Token = token;
        }

        public override string ToString() => Token;
    }
}
