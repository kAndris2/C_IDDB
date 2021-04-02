using System;
using System.Collections.Generic;
using System.Text;

namespace IDDB
{
    public class LoginID
    {
        public String Email { get; set; }
        public String WebPage { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String Comment { get; set; }

        public LoginID(string[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == "")
                    data[i] = "N/A";
            }

            Email = data[0];
            WebPage = data[1];
            UserName = data[2];
            Password = data[3];
        }

        public LoginID(string email, string web, string user, string pass, string comment)
        {
            Email = email;
            WebPage = web;
            UserName = user;
            Password = pass;
            Comment = comment;
        }

        public LoginID() { }

        public override string ToString()
        {
            string text = Comment != null ? $"{Email} - [{Comment}]" : $"{Email}";
            return  $"{text}\n" +
                    $"{WebPage}\n" +
                    $"  - {UserName}\n" +
                    $"  - {Password}";
        }
    }
}
