using Microsoft.AspNetCore.DataProtection;

namespace Emailer.Services
{
    /// <summary>
    /// Helper class for encryption/decryption
    /// </summary>
    public class Encrypter
    {
        private readonly IDataProtector protector;
        public Encrypter(IDataProtectionProvider provider)
        {
            protector = provider.CreateProtector("Encrypter");

        }
        /// <summary>
        /// Encrypts the given payload
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public string Protect(string plainText)
        {
            return protector.Protect(plainText);
        }

        /// <summary>
        /// Decrypts the given cipherText
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        public string Unprotect(string cipherText)
        {
            return protector.Protect(cipherText);
        }
    }
}