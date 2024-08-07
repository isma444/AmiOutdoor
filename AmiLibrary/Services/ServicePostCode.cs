using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmiLibrary.Services
{
    public class ServicePostCode : IServicePostCode
    {
        private IServiceAPI _serviceAPI;
        private string cityURL = "https://api-adresse.data.gouv.fr/search/?q";

        public ServicePostCode(IServiceAPI serviceAPI, string cityName)
        {
            _serviceAPI = serviceAPI;
            this.cityURL += cityName + "&type=municipality";
        }
        public ServicePostCode(string cityName)
        {
            _serviceAPI = new ServiceAPI();
            this.cityURL += cityName + "&type=municipality";
        }
        public ServicePostCode()
        {
            _serviceAPI = new ServiceAPI();
            this.cityURL += "Grenoble&type=municipality";
        }



    }
}
