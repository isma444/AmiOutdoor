using AmiBusiness.Models;
using AmiLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmiLibrary.Services
{
    internal class JsonDeserialisez
    {
        public static WeatherDetails getWeatherDetails(string key, string data)
        {
            var weatherData = JsonConvert.DeserializeObject<WeatherData>(data);
            WeatherDetails weatherdetails = new();
            if (weatherData?.data != null && weatherData.data.TryGetValue(key, out var jToken))
            {
                weatherdetails = jToken.ToObject<WeatherDetails>() ?? new WeatherDetails();
            }
            return weatherdetails;
        }

        public static List<string> getKeyList(string data)
        {
            var list = new List<string>();
            var weatherData = JsonConvert.DeserializeObject<WeatherData>(data) ?? new WeatherData();
            return weatherData.data.Keys.ToList();
        }

        public PostCodeData? GetCoordinates(string data)
        {
            var cityData = JsonConvert.DeserializeObject<CityData>(data);
            if (cityData == null) 
                return null;
            
            return new PostCodeData(cityData.Features.LastOrDefault()!.Properties.Name,
            cityData.Features.LastOrDefault()!.Properties.X,
            cityData.Features.LastOrDefault()!.Properties.Y);

        }
    }
}
