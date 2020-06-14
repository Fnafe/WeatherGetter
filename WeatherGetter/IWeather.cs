﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherGetter
{
    interface IWeather
    {
        /// <summary>
        /// Gets weather information from the API
        /// </summary>
        /// <returns>json object containing weather info for desired region</returns>
        void GetWeather();

        /// <summary>
        /// Displays weather information to the user
        /// </summary>
        void DisplayWeather();
        

    }
}