
﻿
using AmiLibrary.Models;


namespace AmiLibrary.Services
{
    public interface IServiceCalendar
    {
        Task<WeatherDetails> GetWeatherDetails(string cityName, string date);
    }
}
