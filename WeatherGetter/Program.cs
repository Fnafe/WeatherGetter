using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherGetter
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static WeatherCity wc;

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
            while (!endCommands.Contains(userInput))
            {
                userInput = Console.ReadLine();

                Task t = GetWeatherAsync(userInput);
                t.Wait();
            }

            Console.ReadKey();
        }

        // Get weather from openweathermap.org
        public static async Task GetWeatherAsync(string userInput)
        {
            // Make a request to weather API
            string testUrl = @"http://api.openweathermap.org/data/2.5/weather?q=" + userInput + "&APPID=c656c46298cb34e764fd34a3659ad500";
            string resp = "";

            // Check if there was a problem with fetching weather info
            try
            {
                resp = await client.GetStringAsync(testUrl);
            }
            catch (HttpRequestException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wystąpił błąd!");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                return;
            }
            ////jValues = JsonConvert.DeserializeObject<Dictionary<string, object>>(resp);
            ////jValues2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(test);

            // Fill information about weather in specified city
            wc = JsonConvert.DeserializeObject<WeatherCity>(resp);

            DisplayWeather();
        }

        // Display weather to the user
        public static void DisplayWeather()
        {
            Console.WriteLine(wc.name);
        }
    }
}
