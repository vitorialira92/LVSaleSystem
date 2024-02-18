using System.Security.Cryptography;

namespace LVSaleSystem.API.Util
{
    internal static class HashUtil
    {
        internal static (string hashed, string salt) GetHashedAndSalt(string input)
        {
            (string hashed, string salt) result;

            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }

            result.salt = Convert.ToBase64String(saltBytes);

            using (var deriveBytes = new Rfc2898DeriveBytes(input, saltBytes, 10000))
            {
                byte[] hashBytes = deriveBytes.GetBytes(20);

                result.hashed = Convert.ToBase64String(hashBytes);
            }

            return result;
        }

        internal static bool VerifyInput(string input, string hashed, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);

            byte[] hashBytes;
            using (var deriveBytes = new Rfc2898DeriveBytes(input, saltBytes, 10000))
            {
                hashBytes = deriveBytes.GetBytes(20); 
            }

            byte[] storedHashBytes = Convert.FromBase64String(hashed);

            for (int i = 0; i < storedHashBytes.Length; i++)
            {
                if (hashBytes[i] != storedHashBytes[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
