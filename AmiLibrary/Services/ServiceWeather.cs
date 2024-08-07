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
        private IServiceAPI _serviceAPI;
        private IServicePostCode _servicePostCode;
        private PostCodeData _postCodeData;

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

    }
}
