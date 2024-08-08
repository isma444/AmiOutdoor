using AmiLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmiLibrary.Services
{
    public class ServicePostCode : IServicePostCode
    {
        private string _cityURL = "https://api-adresse.data.gouv.fr/search/?q";

        private JsonDeserialisez _deserialisez = new JsonDeserialisez();
        private IServiceAPI _serviceAPI;

        public ServicePostCode(IServiceAPI serviceAPI)
        {
            _serviceAPI = serviceAPI;
        }
        public ServicePostCode()
        {
            _serviceAPI = new ServiceAPI();
        }

        public async Task<PostCodeData> GetPostCodeData(string cityName)
        {
            _cityURL += cityName + "&type=municipality";
            string postCodeData = await _serviceAPI.CallWebApi(_cityURL);
            return _deserialisez.GetCoordinates(postCodeData);
        }
    }
}
