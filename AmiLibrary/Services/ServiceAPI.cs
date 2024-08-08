using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AmiLibrary.Services
{
    public class ServiceAPI : IServiceAPI
    {
        public async Task<string> CallWebApi(string ApiURl)
        {
            var client = new HttpClient { BaseAddress = new Uri(ApiURl) };

            client.BaseAddress = new Uri(ApiURl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(ApiURl);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return "";
            }

        }
    }
}
