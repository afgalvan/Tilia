using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using Domain.Users;
using Encryptor = BCrypt.Net.BCrypt;
using Domain.Users.Repositories;

namespace Application.Users.Authenticate
{
    public class UserAuthenticator
    {
        private readonly IUserRepository _userRepository;

        public UserAuthenticator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> Authenticate(string usernameOrEmail, string password, CancellationToken cancellation)
        {
            User user = await _userRepository.GetUserByEmailOrUsername(usernameOrEmail, cancellation);
            if (user == null)
            {
                throw new AuthenticationException("El usuario no existe.");
            }

            if (!Encryptor.EnhancedVerify(password, user.Password))
            {
                throw new AuthenticationException("Combinación de usuario y contraseña incorrecta.");
            }

            return user.Id.ToString();
        }
    }
}
