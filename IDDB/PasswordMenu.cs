using System;
using System.Collections.Generic;
using System.Text;

namespace IDDB
{
    class PasswordMenu : Menu
    {
        protected override void ShowMenu()
        {
            Console.WriteLine("[PASSWORD Menu]:\n");
            List<string> options = new List<string>
            {
                "Add new password.",
                "Get passwords.",
                "Delete password."
            };

            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"({i + 1}). - {options[i]}");
            }
            Console.WriteLine("\n(0). - Back to Main menu.");
        }

        protected override bool MenuFunctions()
        {
            Console.WriteLine($"\nPlease enter an index to choose a function:");
            string input = Console.ReadLine();

            if (input == "0")
            {
                return false;
            }
            else if (input == "1")
            {
                Console.Clear();

                Console.WriteLine("Enter your password:");
                data.AddPassword(new Password(Console.ReadLine()));
                data.SavePasswords();

                Console.Clear();
                logger.Info("You have successfully added a new password!");
                WaitToKey();

                return true;
            }
            else if (input == "2")
            {
                Console.Clear();

                if (data.Passwords.Count == 0)
                    throw new ListCountZero("You didn't created any password yet!");

                for (int i = 0; i < data.Passwords.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {data.Passwords[i].ToString()}");
                }
                WaitToKey();

                return true;
            }
            else if (input == "3")
            {
                Console.Clear();

                if (data.Passwords.Count == 0)
                    throw new ListCountZero("You didn't created any password yet!");

                data.RemovePassword(GetPassword(data.Passwords));
                data.SavePasswords();

                Console.Clear();
                logger.Info("You have successfully deleted a password!");
                WaitToKey();

                return true;
            }
            else
                throw new KeyNotFound($"There is no such option! - ('{input}')");
        }
    }
}
