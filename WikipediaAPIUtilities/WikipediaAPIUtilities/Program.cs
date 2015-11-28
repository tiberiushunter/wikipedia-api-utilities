using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikipediaAPIUtilities
{
    class Program
    {
        static void Main(string[] args)
        {
            showOptions();
        }

        private static void showOptions()
        {
            Console.WriteLine("Welcome to the Wikipedia API Utilities Console Application");
            Console.WriteLine();
            Console.WriteLine("Please select an option below");
            Console.WriteLine("1 - WikiWars");
            ConsoleKeyInfo _choice = Console.ReadKey();
            string _strChoice = _choice.KeyChar.ToString();
            startProgram(_strChoice);
        }

        private static void startProgram(string _strChoice)
        {
            Console.Clear();
            if (_strChoice == "1")
            {
                Wikiwars w = new Wikiwars();
            }
            else
            {
                Console.WriteLine("'" + _strChoice + "' is not a valid input, please try again.");
                Console.WriteLine();
                showOptions();
            }
        }
    }
}
