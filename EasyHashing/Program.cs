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
        static void Main(string[] args)
        {
            //put tests in here, so they cant be accesed by users
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
    }
}
