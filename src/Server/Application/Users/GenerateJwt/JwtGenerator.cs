using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Domain.Users;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Application.Users.GenerateJwt
{
    public class JwtGenerator
    {
        private const    int                  TokenDaysDuration = 7;
        private readonly SecretKey            _secret;
        private readonly SecurityTokenHandler _tokenHandler;

        public JwtGenerator(SecretKey secret, SecurityTokenHandler tokenHandler)
        {
            _secret       = secret;
            _tokenHandler = tokenHandler;
        }

        public string Generate(User user)
        {
            IEnumerable<Claim>      claims = GenerateClaims(user);
            SecurityTokenDescriptor tokenDescriptor = CreateTokenSpecification(claims);
            SecurityToken           token = _tokenHandler.CreateToken(tokenDescriptor);

            return _tokenHandler.WriteToken(token);
        }

        private static IEnumerable<Claim> GenerateClaims(User user)
        {
            return new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };
        }

        private SecurityTokenDescriptor CreateTokenSpecification(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret.Key));
            var signInCredentials =
                new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            return new SecurityTokenDescriptor
            {
                Subject            = new ClaimsIdentity(claims),
                Expires            = DateTime.Now.AddDays(TokenDaysDuration),
                SigningCredentials = signInCredentials
            };
        }
    }
}
