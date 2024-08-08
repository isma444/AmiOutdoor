using AmiLibrary.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmiLibrary.Services
{
    public class ServiceWeather : IServiceWeather
    {
        private string _urlWeather = "http://www.infoclimat.fr/public-api/gfs/json?_ll=";

        private string _weatherData = "";

        private JsonDeserialisez _deserialisez = new JsonDeserialisez();
        private IServiceAPI _serviceAPI;
        private IServicePostCode _servicePostCode;

        public ServiceWeather(IServiceAPI serviceAPI, IServicePostCode servicePostCode)
        {
            _serviceAPI = serviceAPI;
            _servicePostCode = servicePostCode;
        }
        public ServiceWeather()
        {
            _serviceAPI = new ServiceAPI();
            _servicePostCode = new ServicePostCode();
        }

        public async Task<WeatherDetails> GetWeatherDetails(string cityName, string date)
        {
            PostCodeData postCodeData = await _servicePostCode.GetPostCodeData(cityName);
            if (!_weatherData.Contains(date))
            {
                _weatherData = await GetWeatherData(postCodeData);
            }
            return _deserialisez.GetWeatherDetails(date, _weatherData);
        }

        public async Task<string> GetWeatherData(PostCodeData postCodeData)
        {

             _urlWeather += postCodeData.longitude.ToString(new CultureInfo("en-EN"))+ "," + postCodeData.latitude.ToString(new CultureInfo("en-EN"))+ "&_auth=AxlRRgF%2FUHJSfwA3AXcKI1I6UmcBdwcgVytXNAlsUC1UP14%2FVDRXMQRqBHlXeAUzUXwAYw02CTlTOAZ%2BCXtUNQNpUT0BalA3Uj0AZQEuCiFSfFIzASEHIFc8VzkJelA3VDdeJFQ2Vz0EaAR4V2YFOVFjAH8NLQkwUzcGYwlnVDYDYFE1AWpQNlI0AH0BLgo4UmdSYAE6BzlXYVdiCWVQMlQzXj5UN1c1BGMEeFdmBTNRagBkDTsJMlMzBmQJe1QoAxlRRgF%2FUHJSfwA3AXcKI1I0UmwBag%3D%3D&_c=2e86dbc38267d25d9ab17f5edc981a9a";
            return await _serviceAPI.CallWebApi(_urlWeather);
        }

    }
}
