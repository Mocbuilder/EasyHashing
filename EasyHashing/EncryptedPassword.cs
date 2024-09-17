using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHashing
{
    public class EncryptedPassword
    {
        string Name {  get; set; }

        byte[] Hash {  get; set; }

        public EncryptedPassword(string name)
        {
            name = Name;
        }

        public void EncryptPassword(string pwPlain, string salt)
        {
            byte[] pwByte = EHService.ToByte(pwPlain);
            byte[] saltByte = EHService.ToByte(salt);

            byte[] pwEncrypted = EHService.GenerateSaltedHash(pwByte, saltByte);
            this.Hash = pwEncrypted;
        }

        public bool CheckPassword(byte[] toCompare)
        {
            if (EHService.CompareByteArrays(this.Hash, toCompare) == true)
                return true;
            else 
                return false;
        }
    }
}
