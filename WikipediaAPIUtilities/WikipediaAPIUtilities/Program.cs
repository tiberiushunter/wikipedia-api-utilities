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
            Console.WriteLine("Welcome to the Wikipedia API Utilities Console Application");
            Console.WriteLine("Please select the option below");
            Console.WriteLine("1) WikiWars");
            var result = Console.ReadLine();

            //Convert.ToInt32(result);

            if (result == "1")
            {
                Wikiwars w = new Wikiwars();
            }
        }
    }
}
