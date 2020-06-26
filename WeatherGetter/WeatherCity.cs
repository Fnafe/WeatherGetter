using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherGetter
{
    /// <summary>
    /// Stores information about weather in a city
    /// </summary>
    class WeatherCity : IWeatherCity
    {
        #region Current Weather

        /// <summary>
        /// Stores lattitude and longitude coordinates of the choosen city 
        /// (should be set by JsonConvert only unless you know what you're doing)
        /// </summary>
        public Dictionary<string, float> coord;

        /// <summary>
        /// Stores temperature info of the choosen city 
        /// (should be set by JsonConvert only unless you know what you're doing)
        /// </summary>
        public Dictionary<string, float> main;

        /// <summary>
        /// Stores clouds information of the choosen city 
        /// (should be set by JsonConvert only unless you know what you're doing)
        /// </summary>
        public List<Dictionary<string, string>> weather;

        /// <summary>
        /// Stores additional info for the choosen city 
        /// (should be set by JsonConvert only unless you know what you're doing)
        /// </summary>
        public Dictionary<string, string> sys;

        /// <summary>
        /// Stores the name of the choosen city 
        /// (should be set by JsonConvert only unless you know what you're doing)
        /// </summary>
        public string name;

        /// <summary>
        /// Returns current average temperature measured in a region
        /// </summary>
        public string GetCelsiusTemperature()
        {
            float originalTemperature;

            originalTemperature = main["temp"];

            return Math.Round(originalTemperature - 272.15f, 2).ToString();
        }

        /// <summary>
        /// Returns current minimum temperature measured in a region
        /// </summary>
        public string GetMinCelsiusTemperature()
        {
            float originalTemperature;

            originalTemperature = main["temp_min"];

            return Math.Round(originalTemperature - 272.15f, 2).ToString();
        }

        /// <summary>
        /// Returns current maximum temperature measured in a region
        /// </summary>
        public string GetMaxCelsiusTemperature()
        {
            float originalTemperature;

            originalTemperature = main["temp_max"];

            return Math.Round(originalTemperature - 272.15f, 2).ToString();
        }

        #endregion /Current Weather

        #region Forecast Weather

        /// <summary>
        /// Stores one-day forecast temperature info (should be set by JsonConvert only unless you know what you're doing)
        /// </summary>
        public Dictionary<string, float> temp;

        /// <summary>
        /// Returns temperature in the morning in celsius 
        /// </summary>
        public string GetMorningCelsiusTemperature()
        {
            float originalTemperature;

            originalTemperature = temp["morn"];

            return Math.Round(originalTemperature - 272.15f, 2).ToString();
        }

        /// <summary>
        /// Returns temperature during the day in celsius 
        /// </summary>
        public string GetDayCelsiusTemperature()
        {
            float originalTemperature;

            originalTemperature = temp["day"];

            return Math.Round(originalTemperature - 272.15f, 2).ToString();
        }

        /// <summary>
        /// Returns temperature in the night in celsius 
        /// </summary>
        public string GetNightCelsiusTemperature()
        {
            float originalTemperature;

            originalTemperature = temp["night"];

            return Math.Round(originalTemperature - 272.15f, 2).ToString();
        }

        #endregion /Forecast Weather
    }
}


/*
SAMPLE WEATHER API RESPONSE:
{
"coord":{"lon":21.01,"lat":52.23},
"weather":[{"id":802,"main":"Clouds","description":"scattered clouds","icon":"03d"}],
"base":"stations",
"main":{"temp":295.2,"feels_like":293.39,"temp_min":294.26,"temp_max":296.48,"pressure":1014,"humidity":46},
"visibility":10000,
"wind":{"speed":2.6,"deg":350}
,"clouds":{"all":40},
"dt":1592220810,
"sys":{"type":1,"id":1713,"country":"PL","sunrise":1592187247,"sunset":1592247540},
"timezone":7200,
"id":756135,
"name":"Warsaw",
"cod":200
}
*/