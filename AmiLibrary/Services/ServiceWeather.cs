using AmiBusiness.Models;
using AmiLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmiLibrary.Services
{
    public class ServiceWeather : IServiceWeather
    {
        private string _urlWeather = "http://www.infoclimat.fr/public-api/gfs/json?_ll=";

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

        public async Task<WeatherDetails> GetWeatherDetails(string cityName)
        {
            PostCodeData postCodeData = await _servicePostCode.GetPostCodeData(cityName);
            return _deserialisez.GetWeatherDetails("2024-08-07 23:00:00", await GetWeatherData(postCodeData));
        }

        public async Task<string> GetWeatherData(PostCodeData postCodeData)
        {

             _urlWeather += postCodeData.latitude + "," + postCodeData.longitude + "&_auth=AxlRRgF%2FUHJSfwA3AXcKI1I6UmcBdwcgVytXNAlsUC1UP14%2FVDRXMQRqBHlXeAUzUXwAYw02CTlTOAZ%2BCXtUNQNpUT0BalA3Uj0AZQEuCiFSfFIzASEHIFc8VzkJelA3VDdeJFQ2Vz0EaAR4V2YFOVFjAH8NLQkwUzcGYwlnVDYDYFE1AWpQNlI0AH0BLgo4UmdSYAE6BzlXYVdiCWVQMlQzXj5UN1c1BGMEeFdmBTNRagBkDTsJMlMzBmQJe1QoAxlRRgF%2FUHJSfwA3AXcKI1I0UmwBag%3D%3D&_c=2e86dbc38267d25d9ab17f5edc981a9a";
            return await _serviceAPI.CallWebApi(_urlWeather);
        }

    }
}
