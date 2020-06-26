using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherGetter
{
    /// <summary>
    /// Stores information about weather forecast for a city
    /// </summary>
    class WeatherCityForecast
    {
        /// <summary>
        /// Stores 7-days weather forecast (should be set by JsonConvert only unless you know what you're doing) 
        /// </summary>
        public List<object> daily;

        /// <summary>
        /// Returns weather forecast for the next day
        /// </summary>
        public WeatherCity Tommorow
        {
            get
            {
                return JsonConvert.DeserializeObject<WeatherCity>(daily[1].ToString());
            }
            private set { }
        }
    }
}