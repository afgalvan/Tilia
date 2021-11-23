using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using Application.Users.GenerateJwt;
using Domain.Users;
using Encryptor = BCrypt.Net.BCrypt;
using Domain.Users.Repositories;

namespace Application.Users.Authenticate
{
    public class UserAuthenticator
    {
        private readonly JwtGenerator     _jwtGenerator;
        private readonly IUsersRepository _usersRepository;

        public UserAuthenticator(IUsersRepository usersRepository, JwtGenerator jwtGenerator)
        {
            _usersRepository = usersRepository;
            _jwtGenerator    = jwtGenerator;
        }

        public async Task<string> Authenticate(string usernameOrEmail, string password,
            CancellationToken cancellation)
        {
            User user =
                await _usersRepository.GetUserByEmailOrUsername(usernameOrEmail, cancellation);
            if (user == null)
            {
                throw new AuthenticationException("El usuario no existe.");
            }

            if (!Encryptor.EnhancedVerify(password, user.Password))
            {
                throw new AuthenticationException(
                    "Combinación de usuario y contraseña incorrecta.");
            }

            return _jwtGenerator.Generate(user);
        }
    }
}
