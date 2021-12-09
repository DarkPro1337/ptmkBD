using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ptmkBD
{
    public class SelectScript
    {
        public static async Task Execute()
        {
            Console.WriteLine("Hello, welcome to the script selection screen!");
            Console.WriteLine("");
            Console.WriteLine("Choose script to execute:");
            Console.WriteLine("1. Create database and table.");
            Console.WriteLine("2. Create record in table.");
            Console.WriteLine("3. Select records with unique 'Full Name' and 'Date', with sorting by 'Full Name'");
            Console.WriteLine("4. Fill table with 1000000 records.");
            Console.WriteLine("5. Select 'Full Name' records starting from 'F'");
            Console.WriteLine("");
            Console.Write("It's time to choose: ");

            string input = Console.ReadLine();

            if (input == "1")
            {
                Console.Clear();
                await Script1.Execute();
                Console.Write("Return to script selection screen?: (y/n) ");
                if (Console.ReadLine() == "y")
                {
                    Console.Clear();
                    await Execute();
                } else {
                    Environment.Exit(0);
                }
            } 
            else if (input == "2")
            {
                Console.Clear();
                await Script2.Execute();
                Console.Write("Return to script selection screen?: (y/n) ");
                if (Console.ReadLine() == "y")
                {
                    Console.Clear();
                    await Execute();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            else if (input == "3")
            {
                Console.Clear();
                await Script3.Execute();
                Console.Write("Return to script selection screen?: (y/n) ");
                if (Console.ReadLine() == "y")
                {
                    Console.Clear();
                    await Execute();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            else if (input == "4")
            {
                Console.Clear();
                await Script4.Execute();
                Console.Write("Return to script selection screen?: (y/n) ");
                if (Console.ReadLine() == "y")
                {
                    Console.Clear();
                    await Execute();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            else if (input == "5")
            {
                Console.Clear();
                await Script5.Execute();
                Console.Write("Return to script selection screen?: (y/n) ");
                if (Console.ReadLine() == "y")
                {
                    Console.Clear();
                    await Execute();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.WriteLine("Unknown command. Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                await Execute();
            }
        }
    }
}
