using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherGetter
{
    class Program
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

            Tutorial.ShowTutorial();

            // Main Program Loop
            while (!endCommands.Contains(userInput))
            {
                Console.WriteLine("");

                Console.Write("Wprowadź polecenie: ");
                userInput = Console.ReadLine();
                ExecuteUserCommand(userInput);
            }

            Console.ReadKey();
        }

        private static void ExecuteUserCommand(string userInput)
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

        private static void ShowHelp()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Aby wyjsc wpisz: zakoncz");
            Console.WriteLine("Aby wyswietlic obecna pogode wpisz: teraz nazwa miasta");
            Console.WriteLine("Aby wyswietlic prognoze na jutro wpisz: jutro nazwa miasta");
            Console.WriteLine("Aby wyswietlic ten ekran wpisz: pomoc");
            Console.WriteLine("---------------------------");
        }

        private static void ShowCurrentWeatherForCity(string city)
        {
            Task t = WeatherAPI.GetWeatherAsync(city);
            t.Wait();
            WeatherAPI.DisplayCurrentWeather();
        }

        private static void ShowTommorowWeatherForCity(string city)
        {
            Task t = WeatherAPI.GetWeatherAsync(city);
            t.Wait();
            t = WeatherAPI.GetWeatherForecastAsync();
            t.Wait();
            WeatherAPI.DisplayForecastWeather();
        }

        private static void DisplayCommandNotFound()
        {
            Console.WriteLine("Nie znaleziono takiego polecenia !");
        }
    }
}
