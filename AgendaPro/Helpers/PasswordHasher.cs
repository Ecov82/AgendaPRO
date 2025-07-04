﻿using System.Security.Cryptography;
using System.Text;

namespace AgendaPro.Helpers
{
    public static class PasswordHasher
    {
        public static string ComputeHash(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hashBytes = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }
    }
}
