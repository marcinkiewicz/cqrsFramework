using System;
using System.Security.Cryptography;
using System.Text;

namespace Marcinkiewicz.CqrsFramework.Security.Services
{
    /// <summary>
    /// Default password hasher
    /// </summary>
    public class PasswordService : IPasswordService
    {
        /// <inheritdoc />
        public string GenerateHash(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password must contain at least one no-whitespace character.");
            }

            return HashPassword(password);
        }

        /// <inheritdoc />
        public string GenerateRandomPasswordHash()
        {
            return HashPassword(Guid.NewGuid().ToString());
        }

        /// <inheritdoc />
        public bool Validate(string password, string hash)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password must contain at least one no-whitespace character.");
            }

            if (string.IsNullOrWhiteSpace(hash))
            {
                throw new ArgumentException("Password must contain at least one no-whitespace character.");
            }

            return VerifyHashedPassword(hash, password);
        }

        /// <summary>
        /// <see cref="https://stackoverflow.com/questions/20621950/asp-net-identity-default-password-hasher-how-does-it-work-and-is-it-secure"/>
        /// </summary>
        private static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        /// <summary>
        /// <see cref="https://stackoverflow.com/questions/20621950/asp-net-identity-default-password-hasher-how-does-it-work-and-is-it-secure"/>
        /// </summary>
        private static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return ByteArraysEqual(buffer3, buffer4);
        }

        private static bool ByteArraysEqual(byte[] b1, byte[] b2)
        {
            return Encoding.ASCII.GetString(b1) == Encoding.ASCII.GetString(b2);
        }

    }
}
