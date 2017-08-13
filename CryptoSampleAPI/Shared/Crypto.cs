using System.Text;
using PCLCrypto;
using System;

namespace CryptoSample
{
    public static class Crypto
    {
        private static byte[] keyMaterial = System.Convert.FromBase64String("P9KcPLf+q21f9DUnI0cyP1xgALRa8+uKfZXiNIcjphM=");
        private static byte[] IV = System.Convert.FromBase64String("lEvSlTN0Q7gu9sAUvPTySQ==");
        
        public static string Encrypt(string data)
        {
            var provider = WinRTCrypto.SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithm.AesCbcPkcs7);
            var key = provider.CreateSymmetricKey(keyMaterial);
            var encryptBytes = WinRTCrypto.CryptographicEngine.Encrypt(key, Encoding.UTF8.GetBytes(data), IV);
            return Convert.ToBase64String(encryptBytes);
        }

        public static string Decrypt(string data)
        {
            var provider = WinRTCrypto.SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithm.AesCbcPkcs7);
            var key = provider.CreateSymmetricKey(keyMaterial);
            var encryptBytes = Convert.FromBase64String(data);
            var decryptBytes = WinRTCrypto.CryptographicEngine.Decrypt(key, encryptBytes, IV);
            return Encoding.UTF8.GetString(decryptBytes, 0, decryptBytes.Length);
        }
    }
}