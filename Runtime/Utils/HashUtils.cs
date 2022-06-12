using System;
using System.Security.Cryptography;
using System.Text;

namespace com.liteninja.utils
{
    public static class HashUtils
    {
        /// <summary>
        /// Convert string to Hash using Sha512
        /// </summary>
        public static string CreateHashSha512(string val)
        {
            if (val.IsNullOrEmpty())
            {
                throw new ArgumentException("val");
            }

            var sb = new StringBuilder();
            using (var hash = SHA512.Create())
            {
                var data = hash.ComputeHash(val.ToBytes());
                foreach (var b in data)
                {
                    sb.Append(b.ToString("x2"));
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Convert string to Hash using Sha256
        /// </summary>
        public static string CreateHashSha256(string val)
        {
            if (val.IsNullOrEmpty())
            {
                throw new ArgumentException("val");
            }

            var sb = new StringBuilder();
            using (var hash = SHA256.Create())
            {
                var data = hash.ComputeHash(val.ToBytes());
                foreach (var b in data)
                {
                    sb.Append(b.ToString("x2"));
                }
            }

            return sb.ToString();
        }
    }
}