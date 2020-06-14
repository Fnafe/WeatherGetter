using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherGetter
{
    class Program : IWeather
    {
        static List<string> endCommands = new List<string>() {
            "koniec",
            "stop",
            "zakończ",
            "zamknij",
            "zakoncz"
        };

        static void Main(string[] args)
        {
            string userInput = "";

            // Main Program Loop
            while (endCommands.Contains(userInput))
            {
                userInput = Console.ReadLine();
            }
        }

        public void GetWeather()
        {
            // Make a call to weather API
            
        }

        public void DisplayWeather()
        {

        }
    }
}
