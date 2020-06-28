using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherGetter
{
    interface IWeatherCity
    {
        string GetCelsiusTemperature(); // Average current temperature
        string GetMinCelsiusTemperature(); // Minimum current temperature
        string GetMaxCelsiusTemperature(); // Maximum current temperature

        string GetMorningCelsiusTemperature(); // Forecast temperature in the morning
        string GetDayCelsiusTemperature(); // Forecast temperature during the day
        string GetNightCelsiusTemperature(); // Forecast temperature in the night
    }
}
