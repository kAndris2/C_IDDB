using System;
using System.Collections.Generic;
using System.Text;

namespace IDDB
{
    class EmailMenu : Menu
    {
        protected override void ShowMenu()
        {
            Console.WriteLine("[E-MAIL Menu]:\n");
            List<string> options = new List<string>
            {
                "Add new e-mail address.",
                "Get e-mail addresses.",
                "Add comment to e-mail address.",
                "Delete e-mail address.",
                "Delete comment."
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

                Console.WriteLine("Enter your new e-mail address:");
                data.AddAddress(new Email(Console.ReadLine()));
                data.SaveAddresses();

                Console.Clear();
                logger.Info("You have successfully added a new e-mail address!");
                WaitToKey();

                return true;
            }
            else if (input == "2")
            {
                Console.Clear();

                if (data.Addresses.Count == 0)
                    throw new ListCountZero("You didn't created any address yet!");

                for (int i = 0; i < data.Addresses.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {data.Addresses[i].ToString()}");
                }
                WaitToKey();

                return true;
            }
            else if (input == "3")
            {
                Console.Clear();

                if (data.Addresses.Count == 0)
                    throw new ListCountZero("You didn't created any address yet!");

                Email email = GetEmail(data.Addresses);
                Console.WriteLine("Enter a comment for your e-mail address:");
                email.Comment = Console.ReadLine();
                data.SaveAddresses();

                Console.Clear();
                logger.Info("You have successfully added a comment!");
                WaitToKey();

                return true;
            }
            else if (input == "4")
            {
                Console.Clear();

                if (data.Addresses.Count == 0)
                    throw new ListCountZero("You didn't created any address yet!");

                data.RemoveAddress(GetEmail(data.Addresses));
                data.SaveAddresses();

                Console.Clear();
                logger.Info("You have successfully deleted an address!");
                WaitToKey();

                return true;
            }
            else if (input == "5")
            {
                Console.Clear();

                Email email = GetEmail(data.Addresses);
                email.Comment = null;
                data.SaveAddresses();

                logger.Info("You have successfully deleted a comment!");
                WaitToKey();

                return true;
            }
            else
                throw new KeyNotFound($"There is no such option! - ('{input}')");
        }
    }
}
