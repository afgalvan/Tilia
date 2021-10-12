using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Application.Users.EncryptPassword
{
    public class Hasher
    {
        private readonly byte[] _salt = new byte[128 / 8];

        public string Hash(string password)
        {
            using var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(_salt);

            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password,
                _salt,
                KeyDerivationPrf.HMACSHA1,
                10000,
                256 / 8));
        }
    }
}
