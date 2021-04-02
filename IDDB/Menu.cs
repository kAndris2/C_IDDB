using System;
using System.Collections.Generic;
using System.Text;

namespace IDDB
{
    abstract class Menu
    {
        protected DataManager data = null;
        protected ConsoleLogger logger = null;

        protected abstract void ShowMenu();
        protected abstract bool MenuFunctions();

        public Menu()
        {
            data = DataManager.Singleton;
            logger = new ConsoleLogger();
        }

        public void Start()
        {
            while (true)
            {
                ShowMenu();
                try
                {
                    if (!MenuFunctions())
                        break;
                    else
                    {
                        Console.Clear();
                    }
                }
                catch (MyExceptions e)
                {
                    Console.Clear();
                    logger.Error(e.Message);
                }
            }
        }

        protected Email GetEmail(List<Email> data)
        {
            Console.Clear();

            Console.WriteLine("EMAIL Selection:\n");
            for (int i = 0; i < data.Count; i++)
            {
                Console.WriteLine($"({i + 1}). - {data[i].ToString()}");
            }

            Console.WriteLine("\nChoose an address index:");
            int num = CheckString(Console.ReadLine(), data.Count);

            Console.Clear();

            return data[num - 1];
        }

        protected Password GetPassword(List<Password> data)
        {
            Console.Clear();

            Console.WriteLine("Password Selection:\n");
            for (int i = 0; i < data.Count; i++)
            {
                Console.WriteLine($"({i + 1}). - {data[i].ToString()}");
            }

            Console.WriteLine("\nChoose a password index:");
            int num = CheckString(Console.ReadLine(), data.Count);

            Console.Clear();

            return data[num - 1];
        }

        protected void WaitToKey()
        {
            Console.WriteLine("\n--->[Press enter to continue.]");
            Console.ReadKey();
        }

        protected int CheckString(string str, int count)
        {
            int number;

            if (!int.TryParse(str, out number))
                throw new KeyNotFound($"The entered value is not a number! - ('{str}')");
            if (number > count || number <= 0)
                throw new KeyNotFound($"There is no such option! - ('{number}')");

            return number;
        }
    }
}
