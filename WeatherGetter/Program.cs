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

                if (Controller.language == Controller.Lang.pl)
                {
                    Console.Write("Wprowadź polecenie: ");
                }
                else if (Controller.language == Controller.Lang.en)
                {
                    Console.Write("Input a command: ");
                }
                userInput = Console.ReadLine();
                userInput.ToLower();
                Controller.ExecuteUserCommand(userInput);
            }

            //Console.ReadKey(); // Debug only
        }
    }
}
