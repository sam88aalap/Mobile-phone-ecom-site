using ShopOn.BusinessLayer.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOn.BusinessLayer.Implementation
{
    public class UserManager
    {
        private StringExtension stringEncryption = new StringExtension();
        
        public string PasswordEncrypter(string password)
        {
            return stringEncryption.EncryptString(password);
        }

    }
}
