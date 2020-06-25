using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace WeatherGetter
{
    static class WeatherAPI
    {
        private static readonly HttpClient client = new HttpClient();

        static WeatherCity wc; // Current weather
        static WeatherCityForecast wcf; // Weather forecast

        // English to polish weather dictionary
        static Dictionary<string, string> weatherDictionary = new Dictionary<string, string>()
        {
            {"clouds", "pochmurno"},
            {"scattered clouds", "Małe zachmurzenie"},
            {"broken clouds", "Średnie zachmurzenie"},
            {"clear sky", "Bezchmurnie"},
            {"few clouds", "Prawie bezchmurnie"},
            {"light rain", "Lekkie opady"},
            {"moderate rain", "Umiarkowane opady"},
            {"strong rain", "Silne opady"}
        };

        // Get weather from openweathermap.org
        public static async Task GetWeatherAsync(string userInput)
        {
            // Make a request to weather API
            string apiCallUrl = @"http://api.openweathermap.org/data/2.5/weather?q=" + userInput + "&APPID=c656c46298cb34e764fd34a3659ad500";
            string resp = "";

            // Check if there was a problem with fetching weather info
            try
            {
                resp = await client.GetStringAsync(apiCallUrl);
            }
            catch (HttpRequestException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine("Wystąpił błąd!");
                Console.WriteLine("Nie znaleziono miasta lub brak połączenia!");
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }

            //Console.WriteLine(resp); //Debug

            // Fill information about weather in specified city
            wc = JsonConvert.DeserializeObject<WeatherCity>(resp);
        }

        public static async Task GetWeatherForecastAsync()
        {
            // Make a request to weather API
            string apiCallUrl = @"http://api.openweathermap.org/data/2.5/onecall?lat=" + wc.coord["lat"] + "&lon=" + wc.coord["lon"] + "&exclude=minutely,hourly,current&APPID=c656c46298cb34e764fd34a3659ad500";
            string resp = "";

            // Check if there was a problem with fetching weather info
            try
            {
                resp = await client.GetStringAsync(apiCallUrl);
            }
            catch (HttpRequestException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nie znaleziono miasta lub brak połączenia!");
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }

            //Console.WriteLine(resp); //Debug

            // Fill information about weather in specified city
            wcf = JsonConvert.DeserializeObject<WeatherCityForecast>(resp);
        }

        // Display weather to the user
        public static void DisplayCurrentWeather()
        {
            string skyInfo = wc.weather[0]["description"];
            if (weatherDictionary.ContainsKey(wc.weather[0]["description"]))
            {
                skyInfo = weatherDictionary[wc.weather[0]["description"]];
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(skyInfo);
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write("Obecna temperatura na zewnątrz wynosi: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(wc.GetCelsiusTemperature() + "°C");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write("Minimalna temperatura w regionie: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(wc.GetMinCelsiusTemperature() + "°C");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write("Maksymalna temperatura w regionie: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(wc.GetMaxCelsiusTemperature() + "°C");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Display forecast weather to the user
        public static void DisplayForecastWeather()
        {
            WeatherCity newWC = wcf.Tommorow;

            string skyInfo = newWC.weather[0]["description"];
            if (weatherDictionary.ContainsKey(newWC.weather[0]["description"]))
            {
                skyInfo = weatherDictionary[newWC.weather[0]["description"]];
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(skyInfo);
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write("Temperatura rano: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(newWC.GetMorningCelsiusTemperature() + "°C");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write("Temperatura w dzień: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(newWC.GetDayCelsiusTemperature() + "°C");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write("Temperatura wieczorem: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(newWC.GetNightCelsiusTemperature() + "°C");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
