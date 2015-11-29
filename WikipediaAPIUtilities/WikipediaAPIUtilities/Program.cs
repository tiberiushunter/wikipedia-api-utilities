using System;

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
            Console.WriteLine("2 - HTML");
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
                Console.WriteLine("Stating WikiWars");
            }
            else if (_strChoice == "2")
            {
                HTML h = new HTML();
                Console.WriteLine("Stating HTML");
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
