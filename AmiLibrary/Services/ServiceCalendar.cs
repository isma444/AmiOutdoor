using AmiBusiness.Models;
using AmiLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmiLibrary.Services
{
    public class ServiceCalendar : IServiceCalendar
    {
        private IServiceWeather _serviceWeather;

        public ServiceCalendar()
        {
            this._serviceWeather = new ServiceWeather();
        }

        public ServiceCalendar(IServiceWeather serviceWeather)
        {
            this._serviceWeather = serviceWeather;
        }

        public async Task<WeatherDetails> GetWeatherDetails(string cityName)
        {
            return await _serviceWeather.GetWeatherDetails(cityName);
        }

    }
}
