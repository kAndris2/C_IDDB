using System;
using System.Collections.Generic;
using System.Text;

namespace IDDB
{
    class LoginMenu : Menu
    {
        protected override void ShowMenu()
        {
            Console.WriteLine("[LOGIN Menu]:\n");
            List<string> options = new List<string>
            {
                "Add new login ID.",
                "Get login IDs by e-mail.",
                "Get all login IDs.",
                "Search by webpage.",
                "Add comment to login ID.",
                "Delete login ID.",
                "Delete login comment."
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

                if (data.Addresses.Count == 0)
                    throw new ListCountZero("You didn't created any address yet!");

                if (data.Passwords.Count == 0)
                    throw new ListCountZero("You didn't created any password yet!");

                List<string> questions = new List<string>
                {
                    "Enter the webpage name:",
                    "Enter your user name:"
                };
                string[] answers = new string[questions.Count + 2];
                answers[0] = GetEmail(data.Addresses).Address;
                answers[answers.Length - 1] = GetPassword(data.Passwords).Pass;

                for (int i = 0; i < questions.Count; i++)
                {
                    Console.WriteLine(questions[i]);
                    answers[i + 1] = Console.ReadLine();
                }

                data.AddLogin(new LoginID(answers));
                data.SaveLogins();

                Console.Clear();
                logger.Info("You have successfully added a new login ID!");
                WaitToKey();

                return true;
            }
            else if (input == "2")
            {
                Console.Clear();

                if (data.Logins.Count == 0)
                    throw new ListCountZero("You didn't created any login yet!");

                Console.WriteLine("Enter an e-mail address:");
                string email = GetEmail(data.Addresses).Address;
                int i = 0;

                foreach (LoginID item in data.Logins)
                {
                    if (item.Email.Equals(email))
                    {
                        Console.WriteLine($"({i + 1}).");
                        Console.WriteLine(item.Comment != null ? $"{item.WebPage} - [{item.Comment}]\n" : $"{item.WebPage}\n" +
                                          $"  - {item.UserName}\n" +
                                          $"  - {item.Password}\n");
                        i++;
                    }
                }
                WaitToKey();

                return true;
            }
            else if (input == "3")
            {
                Console.Clear();

                if (data.Logins.Count == 0)
                    throw new ListCountZero("You didn't created any login yet!");

                int i = 0;
                foreach (LoginID item in data.Logins)
                {
                    Console.WriteLine($"({i + 1}).\n" +
                                      $"{item.ToString()}\n");
                    i++;
                }
                WaitToKey();

                return true;
            }
            else if (input == "4")
            {
                Console.Clear();

                Console.WriteLine("Enter the webpage name:");
                string page = Console.ReadLine().ToLower();

                Console.Clear();
                foreach(LoginID login in data.Logins)
                {
                    if (login.WebPage.Contains(page))
                    {
                        Console.WriteLine(login.ToString() + "\n");
                    }
                }
                WaitToKey();

                return true;
            }
            else if (input == "5")
            {
                Console.Clear();

                if (data.Logins.Count == 0)
                    throw new ListCountZero("You didn't created any login yet!");

                LoginID login = GetLogin(data.Logins);
                Console.WriteLine("Enter a comment for your login ID:");
                login.Comment = Console.ReadLine();
                data.SaveLogins();

                Console.Clear();
                logger.Info("You have successfully added a comment!");
                WaitToKey();

                return true;
            }
            else if (input == "6")
            {
                Console.Clear();

                if (data.Logins.Count == 0)
                    throw new ListCountZero("You didn't created any login yet!");

                data.RemoveLogin(GetLogin(data.Logins));
                data.SaveLogins();

                Console.Clear();
                logger.Info("You have successfully deleted a login!");
                WaitToKey();

                return true;
            }
            else if (input == "7")
            {
                Console.Clear();

                LoginID login = GetLogin(data.Logins);
                login.Comment = null;
                data.SaveLogins();

                logger.Info("You have successfully deleted a comment!");
                WaitToKey();

                return true;
            }
            else
                throw new KeyNotFound($"There is no such option! - ('{input}')");
        }

        private LoginID GetLogin(List<LoginID> data)
        {
            Console.Clear();

            Console.WriteLine("LOGIN Selection:\n");
            for (int i = 0; i < data.Count; i++)
            {
                Console.WriteLine($"({i + 1}). - {data[i].ToString()}\n");
            }

            Console.WriteLine("\nChoose a login index:");
            int num = CheckString(Console.ReadLine(), data.Count);

            Console.Clear();

            return data[num - 1];
        }
    }
}
