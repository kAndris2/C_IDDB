using System;
using System.Collections.Generic;

namespace IDDB
{
    class Program
    {
        const String PASSWORD = "61213991";
        const int MAX_TRY = 3;

        static void Main(string[] args)
        {
            ConsoleLogger logger = new ConsoleLogger();
            PasswordService passwordService = new PasswordService();
            int pTry = 0;

            while (pTry != MAX_TRY)
            {
                Console.WriteLine("Please enter the password to open database:");
                string password = passwordService.GetPassword();
                Console.Clear();

                if (password.Equals(PASSWORD))
                {
                    new MainMenu().Start();
                    break;
                }
                else
                {
                    pTry++;
                    logger.Error($"Invalid password! ({pTry}/{MAX_TRY})");
                }
            }
        }
    }
}
