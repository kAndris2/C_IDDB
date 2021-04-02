using System;
using System.Collections.Generic;
using System.Text;

namespace IDDB
{
    interface ILogger
    {
        void Info(string message);
        void Error(string message);
        void Warning(string message);
    }
}
