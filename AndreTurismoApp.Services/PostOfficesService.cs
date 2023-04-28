using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoApp.Models.DTO;
using Newtonsoft.Json;

namespace AndreTurismoApp.Services
{
    public class PostOfficesService
    {
        static readonly HttpClient address = new HttpClient();
        public static async Task<AddressDTO> GetAddress(string cep)
        {
            try
            {
                HttpResponseMessage response = await PostOfficesService.address.GetAsync("https://viacep.com.br/ws/" + cep + "/json/");
                response.EnsureSuccessStatusCode();
                string ad = await response.Content.ReadAsStringAsync();
                var addressfull = JsonConvert.DeserializeObject<AddressDTO>(ad);
                return addressfull;
            }catch (Exception ex)
            {
                throw;
            }
        }

    }
}
