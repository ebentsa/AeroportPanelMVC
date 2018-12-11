using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AeroportBusinessLogic.AccountMethods
{
    public static class SecurePasswordHasher
    {


        private const string HashString = "_Kava_$Banga#";


        public static string Hash(string password)
        {
            password = password + HashString;
            SHA384CryptoServiceProvider sha = new SHA384CryptoServiceProvider();
            byte[] Bytestr = Encoding.ASCII.GetBytes(password);
            Bytestr = sha.ComputeHash(Bytestr);
            string finStr = null;

            foreach (var item in Bytestr)
            {
                finStr += item.ToString();
            }

            return finStr.ToUpper();
        }


        public static bool Verify(string password, string hashedPassword)
        {

            if (SecurePasswordHasher.Hash(password) == hashedPassword)
            {
                return true;
            }

            return false;
        }
    }
}
