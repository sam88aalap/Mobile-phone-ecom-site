using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOn.BusinessLayer.Utility
{
    public class StringExtension
    {
        //public void Main()
        //{
        //    string password = "123@aksh";

        //    string encryptedPassword = EncryptString(password);
        //    string decyptedPassword = DecryptString(encryptedPassword);
        //}
        public string DecryptString(string encrPassword)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(encrPassword);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException fe)
            {
                decrypted = "";
            }
            return decrypted;
        }

        public string EncryptString(string password)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(password);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }
    }
}
