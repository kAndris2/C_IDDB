using System;
using System.Collections.Generic;
using System.Text;

namespace IDDB
{
    public class Password
    {
        public String Pass { get; set; }

        public Password() { }

        public Password(string pass)
        {
            Pass = pass;
        }

        public override string ToString()
        {
            return $"{Pass}";
        }
    }
}
