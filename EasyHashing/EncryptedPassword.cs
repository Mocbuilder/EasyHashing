using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHashing
{
    public class EncryptedPassword
    {
        public byte[] Hash {  get; set; }

        public EncryptedPassword()
        {
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
