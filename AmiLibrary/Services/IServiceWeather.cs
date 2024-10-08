
﻿using AmiLibrary.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmiLibrary.Services
{
    public interface IServiceWeather
    {
        string WeatherData { get; }
        Task<WeatherDetails> GetWeatherDetails(string cityName, string date);
    }
}
