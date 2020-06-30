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
        public enum Lang
        {
            en = 0,
            pl
        }

        /// <summary>
        /// Stores "end-program" commands
        /// </summary>
        public static List<string> endCommands = new List<string>() {
            "zakończ",
            "zakoncz",
            "stop",
            "end",
            "finish",
            "exit"
        };

        public static Lang language = Lang.pl;

        ///// <summary>
        ///// Stores weather commands
        ///// </summary>
        //public static List<string> weatherCommands = new List<string>() {
        //    "teraz",
        //    "obecnie",
        //    "now",
        //    "current"
        //};

        /// <summary>
        /// Gets full command, parses and execute it
        /// </summary>
        public static void ExecuteUserCommand(string userInput)
        {
            string[] userCommands = userInput.Split(' ');

            //string translatedCommand = weatherCommands.Contains(userCommands[0]) ? weatherCommands[weatherCommands.IndexOf(userCommands[0])] : "";

            if (language == Lang.pl)
            {
                switch (userCommands[0])
                {
                    case "teraz":
                        userInput = userInput.Remove(0, "teraz ".Length);
                        ShowCurrentWeatherForCity(userInput);
                        break;
                    case "jutro":
                        userInput = userInput.Remove(0, "jutro ".Length);
                        ShowTommorowWeatherForCity(userInput);
                        break;
                    case "pomoc":
                        ShowHelp();
                        break;
                    case "lang":
                        userInput = userInput.Remove(0, "lang ".Length);
                        ChangeLanguage(userInput);
                        break;
                    default:
                        DisplayCommandNotFound();
                        break;
                }
            }
            else if (language == Lang.en)
            {
                switch (userCommands[0])
                {
                    case "now":
                        userInput = userInput.Remove(0, "now ".Length);
                        ShowCurrentWeatherForCity(userInput);
                        break;
                    case "tommorow":
                        userInput = userInput.Remove(0, "tommorow ".Length);
                        ShowTommorowWeatherForCity(userInput);
                        break;
                    case "help":
                        ShowHelp();
                        break;
                    case "lang":
                        userInput = userInput.Remove(0, "lang ".Length);
                        ChangeLanguage(userInput);
                        break;
                    default:
                        DisplayCommandNotFound();
                        break;
                }
            }
        }

        /// <summary>
        /// Changes language field to the choosen language
        /// </summary>
        private static void ChangeLanguage(string lang)
        {
            switch (lang)
            {
                case "pl":
                    language = Lang.pl;
                    Console.WriteLine("Język zmieniony na polski");
                    Console.WriteLine("- Aby wyświetlić pomoc wpisz: \"pomoc\".");
                    break;
                case "en":
                    language = Lang.en;
                    Console.WriteLine("Language switched to English");
                    Console.WriteLine("- To display help type: \"help\".");
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
            if (language == Lang.pl)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("  Aby wyjsc wpisz: zakoncz");
                Console.WriteLine("  Aby wyswietlic obecna pogode wpisz: teraz nazwa miasta");
                Console.WriteLine("  Aby wyswietlic prognoze na jutro wpisz: jutro nazwa miasta");
                Console.WriteLine("  Jeżeli miasto nie zostało odnalezione spróbuj użyć jego angielskiej nazwy");
                Console.WriteLine("  Aby wyswietlic ten tekst wpisz: pomoc");
                Console.WriteLine("  Aby zmienić język wpisz: lang kod_literowy_języka");
                Console.WriteLine("---------------------------");
            }
            else if (language == Lang.en)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("  To exit type: exit");
                Console.WriteLine("  To show current weather type: now city name");
                Console.WriteLine("  To show tommorow forecast type: tommorow city name");
                Console.WriteLine("  To show this text type: help");
                Console.WriteLine("  To change language type: lang language_letter_code");
                Console.WriteLine("---------------------------");
            }
        }

        /// <summary>
        /// Gets and invokes displaying of current weather for a given city
        /// </summary>
        private static void ShowCurrentWeatherForCity(string city)
        {
            Task t = WeatherAPI.GetWeatherAsync(city);
            t.Wait();

            if (WeatherAPI.requestSuccesfull)
            {
                WeatherAPI.DisplayCurrentWeather();
            }
        }

        /// <summary>
        /// Gets and invokes displaying of weather forecast for tommorow for a given city
        /// </summary>
        private static void ShowTommorowWeatherForCity(string city)
        {
            Task t = WeatherAPI.GetWeatherAsync(city);
            t.Wait();

            if (WeatherAPI.requestSuccesfull)
            {
                t = WeatherAPI.GetWeatherForecastAsync();
                t.Wait();
            }

            if (WeatherAPI.requestSuccesfull)
            {
                WeatherAPI.DisplayForecastWeather();
            }
        }

        /// <summary>
        /// Displays the info that the given command was not recognised
        /// </summary>
        private static void DisplayCommandNotFound()
        {
            if (language == Lang.pl)
            {
                Console.WriteLine("Nie znaleziono takiej opcji !");
            }
            else if (language == Lang.en)
            {
                Console.WriteLine("Option not found !");
            }
        }
    }
}

