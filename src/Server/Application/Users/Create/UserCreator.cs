using System.Threading;
using System.Threading.Tasks;
using Application.Users.GenerateJwt;
using Encryptor = BCrypt.Net.BCrypt;
using Domain.Users;
using Domain.Users.Repositories;

namespace Application.Users.Create
{
    public class UserCreator
    {
        private readonly JwtGenerator    _jwtGenerator;
        private readonly IUserRepository _userRepository;

        public UserCreator(JwtGenerator jwtGenerator, IUserRepository userRepository)
        {
            _jwtGenerator   = jwtGenerator;
            _userRepository = userRepository;
        }

        public async Task<string> Create(string username, string email, string password,
            CancellationToken cancellation)
        {
            string hashedPassword = Encryptor.EnhancedHashPassword(password);
            var    user           = new User(username, email, hashedPassword);
            await _userRepository.Save(user, cancellation);
            return _jwtGenerator.Generate(user);
        }
    }
}
