using System.Security.Cryptography;
using System.Text;

namespace EasyHashing
{
    public class EHService
    {


        public static byte[] ToByte(string input)
        {
            byte[] salt = Encoding.ASCII.GetBytes(input);

            return salt;
        }

        public static byte[] ToByte(string input1, string input2)
        {
            byte[] salt = Encoding.ASCII.GetBytes(input1 + input2);

            return salt;
        }

        public static byte[] GenerateSaltedHash(byte[] toEncrypt, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] saltedHash = new byte[toEncrypt.Length + salt.Length];

            for (int i = 0; i < toEncrypt.Length; i++)
            {
                saltedHash[i] = toEncrypt[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                saltedHash[toEncrypt.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(saltedHash);
        }

        public static bool CompareByteArrays(byte[] array1, byte[] array2)
        {
            return array1.SequenceEqual(array2);
        }
    }
}
