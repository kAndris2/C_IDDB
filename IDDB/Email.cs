using System;
using System.Collections.Generic;
using System.Text;

namespace IDDB
{
    public class Email
    {
        public String Address { get; set; }
        public String Comment { get; set; }

        public Email(string address)
        {
            Address = address;
        }

        public Email(string address, string comment)
        {
            Address = address;
            Comment = comment;
        }

        public Email() { }

        public override string ToString()
        {
            return Comment != null ? $"{Address} - [{Comment}]" : $"{Address}";
        }
    }
}
