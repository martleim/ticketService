using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Business.Security
{
    public class SHA256ManagedPasswordEncoder : IPasswordEncoder
    {
        private static readonly byte[] Key =
        {
            123, 218, 19, 11, 24, 26, 85, 45, 114, 184, 27, 162, 37, 112, 222, 209,
            241, 24, 175, 144, 173, 53, 196, 29, 24, 26, 17, 219, 131, 236, 53, 209
        };

        private static readonly byte[] Vector =
        {
            146, 64, 193, 111, 23, 3, 113, 119, 232, 121, 221, 112, 79, 32, 114,
            156
        };

        private readonly ICryptoTransform _decryptor;
        private readonly UTF8Encoding _encoder;
        private readonly ICryptoTransform _encryptor;

        /// <summary>
        /// Initializes a new instance of the <see cref="SHA256ManagedPasswordEncoder" /> class.
        /// </summary>
        public SHA256ManagedPasswordEncoder()
        {
            var rm = new RijndaelManaged();
            rm.Padding = PaddingMode.PKCS7;
            rm.Mode = CipherMode.CBC;
            rm.Key = Key;
            rm.IV = Vector;

            _encryptor = rm.CreateEncryptor();
            _decryptor = rm.CreateDecryptor();

            _encoder = new UTF8Encoding();
        }

        /// <summary>
        /// Encodes the specified password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public string Encode(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                return Convert.ToBase64String(Encrypt(_encoder.GetBytes(password)));
            }
            return password;
        }

        /// <summary>
        /// Decodes the specified encoded password.
        /// </summary>
        /// <param name="encodedPassword">The encoded password.</param>
        /// <returns></returns>
        public string Decode(string encodedPassword)
        {
            if (!string.IsNullOrEmpty(encodedPassword))
            {
                return _encoder.GetString(Decrypt(Convert.FromBase64String(encodedPassword)));
            }
            return encodedPassword;
        }

        private byte[] Encrypt(byte[] buffer)
        {
            return Transform(buffer, _encryptor);
        }

        private byte[] Decrypt(byte[] buffer)
        {
            return Transform(buffer, _decryptor);
        }

        protected byte[] Transform(byte[] buffer, ICryptoTransform transform)
        {
            byte[] result;
            using (var stream = new MemoryStream())
            {
                using (var cs = new CryptoStream(stream, transform, CryptoStreamMode.Write))
                {
                    cs.Write(buffer, 0, buffer.Length);
                    cs.FlushFinalBlock();
                }
                result = stream.ToArray();
            }
            return result;
        }
    }
}
