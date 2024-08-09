
﻿
using AmiLibrary.Models;


namespace AmiLibrary.Services
{
    public interface IServiceCalendar
    {
        string GetWeatherData();
        Task<WeatherDetails> GetWeatherDetails(string cityName, string date);
    }
}
