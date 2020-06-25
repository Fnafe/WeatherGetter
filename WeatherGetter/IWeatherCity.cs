using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherGetter
{
    interface IWeatherCity
    {
        string GetCelsiusTemperature();

        ///// <summary>
        ///// Gets weather information from the API
        ///// </summary>
        ///// <returns>json object containing weather info for desired region</returns>
        //Task GetWeatherAsync(string userInput);

        ///// <summary>
        ///// Displays weather information to the user
        ///// </summary>
        //void DisplayWeather();
    }
}
