using System;
using System.Collections.Generic;
using System.Text;

namespace IDDB
{
    class MyExceptions : Exception
    {
        public MyExceptions(string message) : base(message)
        { }
    }

    class KeyNotFound : MyExceptions
    {
        public KeyNotFound(string message) : base(message)
        { }
    }

    class ListCountZero : MyExceptions
    {
        public ListCountZero(string message) : base(message)
        { }
    }

}
