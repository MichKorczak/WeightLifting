using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Services.Services.Implementations
{
    public class HashServis
    {
        public const int SaltSize = 14;
        public const int HashSize = 22;
        public const int HashIter = 12000;
        public const int HASH_SECTION = 5;
        public const int HASH_ALGORITM_INDEX = 0;
        public const int INTERATION_INDEX = 1;
        public const int HASH_SIZE_INDEX = 2;
        public const int SALT_INDEX = 3;
        public const int PBKDF2_INDEX = 4;

        byte[] salt = null, hash = null;

        public string PasswordHash(string password)
        {
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);
            hash = new Rfc2898DeriveBytes(password, salt, HashIter).GetBytes(HashSize);

            string savePasswordHash = "sha1" + HashIter +
                                      ":" + hash.Length + ":" + Convert.ToBase64String(salt) + 
                                      ":" + Convert.ToBase64String(hash);
            return savePasswordHash;
        }

        public bool VerifityPassword(string password, string goodHash)
        {
            char[] delimer = { ':' };
            string[] split = goodHash.Split(delimer);

            if (split.Length != HASH_SECTION)
                return false;
            if (split[HASH_ALGORITM_INDEX] != "sha1")
                return false;

            int iteration = 0;
            iteration = Int32.Parse(split[INTERATION_INDEX]);
            if (iteration < 1)
                return false;

            salt = Convert.FromBase64String(split[SALT_INDEX]);
            hash = Convert.FromBase64String(split[PBKDF2_INDEX]);

            int storeHashSize = Int32.Parse(split[HASH_SIZE_INDEX]);
            if (storeHashSize != hash.Length)
                return false;

            byte[] testHash = new Rfc2898DeriveBytes(password, salt, HashIter).GetBytes(HashSize);
            return SlowEquals(hash, testHash);
        }

        private bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint) a.Length ^ (uint) b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
                diff |= (uint) (a[i] ^ b[i]);
            return diff == 0;
        }
    }
}
