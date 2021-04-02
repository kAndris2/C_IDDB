using System;
using System.Collections.Generic;
using System.Text;

namespace IDDB
{
    class Encrypt
    {
        //https://stackoverflow.com/questions/10168240/encrypting-decrypting-a-string-in-c-sharp
        private string Encode(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        private static string Decode(string data)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(data));
        }

        public List<Email> EncodeList(List<Email> table)
        {
            List<Email> encoded_table = new List<Email>();

            foreach (Email item in table)
            {
                encoded_table.Add(new Email(Encode(item.Address), Encode(item.Comment)));
            }
            return encoded_table;
        }

        public List<LoginID> EncodeList(List<LoginID> table)
        {
            List<LoginID> encoded_table = new List<LoginID>();

            foreach (LoginID item in table)
            {
                encoded_table.Add(new LoginID(Encode(item.Email),
                                              Encode(item.WebPage), 
                                              Encode(item.UserName), 
                                              Encode(item.Password), 
                                              Encode(item.Comment)
                                              ));
            }
            return encoded_table;
        }
    }
}
