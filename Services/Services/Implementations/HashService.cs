using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using Data.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Services.Services.Interfaces;

namespace Services.Services.Implementations
{
    public class HashService : IHashService
    {
        public string PasswordHash(string password, byte[] salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 32));
            return hashed;
        }

        public byte[] SaltCreated()
        {
            byte[] salt = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

    }
}
