using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;
using TICS.Models;

namespace TICSS.Service
{
    public class PasswordEncryptionService
    {
        private readonly Person _person;
        private readonly string _loginPassword;

        

        public PasswordEncryptionService(Person person, string loginPassword)
        {
            _person = person;
            _loginPassword = loginPassword;
        }

        public void EncryptPassword()
        {
            HashPassword();
        }

        public bool ValidatePassword()
        {
           return VerifyHashedPassword(_person, _loginPassword);
        }


        private string HashPassword()
        {
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: _person.PasswordHash,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            Console.WriteLine($"Hashed: {hashed}");

            return hashed;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p">The Person object, after a lookup has occurred</param>
        /// <param name="password">standard password from the login screen</param>
        /// <returns>True if there is a match, False otherwise</returns>
        private static bool VerifyHashedPassword(Person p, string password)
        {
            const KeyDerivationPrf Pbkdf2Prf = KeyDerivationPrf.HMACSHA1; // default for Rfc2898DeriveBytes
            const int Pbkdf2IterCount = 1000; // default for Rfc2898DeriveBytes
            const int Pbkdf2SubkeyLength = 256 / 8; // 256 bits
            const int SaltSize = 128 / 8; // 128 bits

            // We know ahead of time the exact length of a valid hashed password payload.
            if (p.PasswordHash.Length != 1 + SaltSize + Pbkdf2SubkeyLength)
            {
                return false; // bad size
            }

            byte[] salt = new byte[SaltSize];
            Buffer.BlockCopy(p.PasswordHash.ToCharArray(), 1, salt, 0, salt.Length);

            byte[] expectedSubkey = new byte[Pbkdf2SubkeyLength];
            Buffer.BlockCopy(p.PasswordHash.ToCharArray(), 1 + salt.Length, expectedSubkey, 0, expectedSubkey.Length);

            // Hash the incoming password and verify it
            byte[] actualSubkey = KeyDerivation.Pbkdf2(password, salt, Pbkdf2Prf, Pbkdf2IterCount, Pbkdf2SubkeyLength);

            //the comparison here is done based on the amount of time relative to the length of each byte array
            return CryptographicOperations.FixedTimeEquals(actualSubkey, expectedSubkey);

        }
    }
}
