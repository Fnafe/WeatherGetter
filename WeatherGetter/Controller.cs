using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherGetter
{
    /// <summary>
    /// Executes commands given by the user
    /// </summary>
    static class Controller
    {
        /// <summary>
        /// Stores polish "end" commands
        /// </summary>
        public static List<string> endCommands = new List<string>() {
            "koniec",
            "stop",
            "zakończ",
            "zamknij",
            "zakoncz"
        };

        /// <summary>
        /// Gets full command, parses and execute it
        /// </summary>
        public static void ExecuteUserCommand(string userInput)
        {
            string[] userCommands = userInput.Split(' ');

            switch (userCommands[0])
            {
                case "teraz":
                    userInput = userInput.Remove(0, "dzisiaj".Length);
                    ShowCurrentWeatherForCity(userInput);
                    break;
                case "jutro":
                    userInput = userInput.Remove(0, "jutro".Length);
                    ShowTommorowWeatherForCity(userInput);
                    break;
                case "pomoc":
                    ShowHelp();
                    break;
                default:
                    DisplayCommandNotFound();
                    break;
            }
        }

        /// <summary>
        /// Displays help to the user
        /// </summary>
        private static void ShowHelp()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Aby wyjsc wpisz: zakoncz");
            Console.WriteLine("Aby wyswietlic obecna pogode wpisz: teraz nazwa miasta");
            Console.WriteLine("Aby wyswietlic prognoze na jutro wpisz: jutro nazwa miasta");
            Console.WriteLine("Aby wyswietlic ten ekran wpisz: pomoc");
            Console.WriteLine("---------------------------");
        }

        /// <summary>
        /// Gets and invokes displaying of current weather for a given city
        /// </summary>
        private static void ShowCurrentWeatherForCity(string city)
        {
            Task t = WeatherAPI.GetWeatherAsync(city);
            t.Wait();
            WeatherAPI.DisplayCurrentWeather();
        }

        /// <summary>
        /// Gets and invokes displaying of weather forecast for tommorow for a given city
        /// </summary>
        private static void ShowTommorowWeatherForCity(string city)
        {
            Task t = WeatherAPI.GetWeatherAsync(city);
            t.Wait();
            t = WeatherAPI.GetWeatherForecastAsync();
            t.Wait();
            WeatherAPI.DisplayForecastWeather();
        }

        /// <summary>
        /// Displays the info that the given command was not recognised
        /// </summary>
        private static void DisplayCommandNotFound()
        {
            Console.WriteLine("Nie znaleziono takiego polecenia !");
        }
    }
}

