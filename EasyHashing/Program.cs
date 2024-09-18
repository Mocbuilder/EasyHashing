using EasyHashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHashingTest
{
    internal class Program
    {
        static bool autoTest = false;
        static bool manualTest = true;
        static void Main(string[] args)
        {

            //put tests in here, so they cant be accesed by users
            if (autoTest)
            {
                string username = Console.ReadLine();
                string password = Console.ReadLine();

                EncryptedPassword ehPassword = new EncryptedPassword();
                ehPassword.EncryptPassword(password, username);

                Console.WriteLine("Now for the testing...");
                EncryptedPassword ehPassword2 = new EncryptedPassword();
                ehPassword2.EncryptPassword("adnin", username);
                Console.WriteLine(ehPassword.CheckPassword(ehPassword2.Hash));
                Console.ReadLine();
            }

            if (manualTest)
            {
                string username = Console.ReadLine();
                string password = Console.ReadLine();

                byte[] selfPwByte = EHService.ToByte(password);
                byte[] selfUnByte = EHService.ToByte(username);

                byte[] hash = EHService.GenerateSaltedHash(selfPwByte, selfUnByte);


                byte[] selfPwByte2 = EHService.ToByte("admin");
                byte[] selfUnByte2 = EHService.ToByte("admin");

                byte[] hash2 = EHService.GenerateSaltedHash(selfPwByte2, selfUnByte2);

                Console.WriteLine(EHService.CompareByteArrays(hash, hash2));
            }
            
            Console.ReadLine();
        }
    }
}
