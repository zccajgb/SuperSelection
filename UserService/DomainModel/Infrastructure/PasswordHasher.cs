using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DomainModel.Infrastructure
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password, string salt)
        {
            string str = password + salt;

            var hashedPassword = string.Empty;
            using (var hashAlgorithm = SHA256.Create())
            {
                hashedPassword = GenerateHash(str, hashAlgorithm);
            }

            return hashedPassword;
        }

        private static string GenerateHash(string str, SHA256 hashAlgorithm)
        {
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(str));

            return Convert.ToBase64String(data);
        }
    }
}
