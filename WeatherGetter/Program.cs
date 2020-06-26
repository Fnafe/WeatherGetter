using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherGetter
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = "";

            Tutorial.ShowTutorial();

            // Main Program Loop
            while (!Controller.endCommands.Contains(userInput))
            {
                Console.WriteLine("");

                Console.Write("Wprowadź polecenie: ");
                userInput = Console.ReadLine();
                Controller.ExecuteUserCommand(userInput);
            }

            //Console.ReadKey(); // Debug only
        }
    }
}
