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
        public static bool requestSuccesfull = false;

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
            {"strong rain", "Silne opady"},
            {"overcast clouds", "Przewaga chmur"}
        };

        /// <summary>
        /// Gets weather for a choosen city and asynchronically fills 'wc' object with it
        /// </summary>
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
                DisplayErrorMessage();
                requestSuccesfull = false;
                return;
            }

            //Console.WriteLine(resp); //Debug

            // Fill information about weather in specified city
            wc = JsonConvert.DeserializeObject<WeatherCity>(resp);
            requestSuccesfull = true;
        }

        /// <summary>
        /// Gets weather for a choosen lattitute ang longitude
        /// and asynchronically fills 'wcf' object with it.
        /// WARNING - it REQUIRES 'wc' object to be set
        /// otherwise the api call will fail
        /// </summary>
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
                DisplayErrorMessage();
                requestSuccesfull = false;
                return;
            }

            //Console.WriteLine(resp); //Debug

            // Fill information about weather in specified city
            wcf = JsonConvert.DeserializeObject<WeatherCityForecast>(resp);
            requestSuccesfull = true;
        }

        /// <summary>
        /// Displays the current weather to the user
        /// </summary>
        public static void DisplayCurrentWeather()
        {
            string skyInfo = wc.weather[0]["description"];
            if (weatherDictionary.ContainsKey(wc.weather[0]["description"]))
            {
                if (Controller.language == Controller.Lang.pl)
                {
                    skyInfo = weatherDictionary[wc.weather[0]["description"]];
                }
                else if (Controller.language == Controller.Lang.en)
                {
                    skyInfo = wc.weather[0]["description"];
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(skyInfo);
            Console.ForegroundColor = ConsoleColor.Gray;

            if (Controller.language == Controller.Lang.pl)
            {
                Console.Write("Obecna temperatura na zewnątrz wynosi: ");
            }
            else if (Controller.language == Controller.Lang.en)
            {
                Console.Write("Current temperature outside: ");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(wc.GetCelsiusTemperature() + "°C");
            Console.ForegroundColor = ConsoleColor.Gray;

            if (Controller.language == Controller.Lang.pl)
            {
                Console.Write("Minimalna temperatura w regionie: ");
            }
            else if (Controller.language == Controller.Lang.en)
            {
                Console.Write("Minimal temperature outside: ");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(wc.GetMinCelsiusTemperature() + "°C");
            Console.ForegroundColor = ConsoleColor.Gray;

            if (Controller.language == Controller.Lang.pl)
            {
                Console.Write("Maksymalna temperatura w regionie: ");
            }
            else if (Controller.language == Controller.Lang.en)
            {
                Console.Write("Maximal temperature outside: ");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(wc.GetMaxCelsiusTemperature() + "°C");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Displays weather forecast for tommorow to the user
        /// </summary>
        public static void DisplayForecastWeather()
        {
            WeatherCity newWC = wcf.Tommorow;

            string skyInfo = newWC.weather[0]["description"];
            if (weatherDictionary.ContainsKey(newWC.weather[0]["description"]))
            {
                if (Controller.language == Controller.Lang.pl)
                {
                    skyInfo = weatherDictionary[newWC.weather[0]["description"]];
                }
                else if (Controller.language == Controller.Lang.en)
                {
                    skyInfo = newWC.weather[0]["description"];
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(skyInfo);
            Console.ForegroundColor = ConsoleColor.Gray;

            if (Controller.language == Controller.Lang.pl)
            {
                Console.Write("Temperatura rano: ");
            }
            else if (Controller.language == Controller.Lang.en)
            {
                Console.Write("Morning temperature: ");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(newWC.GetMorningCelsiusTemperature() + "°C");
            Console.ForegroundColor = ConsoleColor.Gray;

            if (Controller.language == Controller.Lang.pl)
            {
                Console.Write("Temperatura w dzień: ");
            }
            else if (Controller.language == Controller.Lang.en)
            {
                Console.Write("Day temperature: ");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(newWC.GetDayCelsiusTemperature() + "°C");
            Console.ForegroundColor = ConsoleColor.Gray;

            if (Controller.language == Controller.Lang.pl)
            {
                Console.Write("Temperatura wieczorem: ");
            }
            else if (Controller.language == Controller.Lang.en)
            {
                Console.Write("Evening temperature: ");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(newWC.GetNightCelsiusTemperature() + "°C");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Writes error message to the console
        /// </summary>
        public static void DisplayErrorMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            if (Controller.language == Controller.Lang.pl)
            {
                Console.WriteLine("Nie znaleziono miasta lub brak połączenia!");
            }
            else if (Controller.language == Controller.Lang.en)
            {
                Console.WriteLine("City not found or connection error!");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
