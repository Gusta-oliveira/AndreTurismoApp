using System.Net;
using AndreTurismoApp.Models;
using Newtonsoft.Json;


namespace AndreTurismoApp.Services
{
    public class AddressService
    {

        static readonly HttpClient addressClient = new HttpClient();
        public async Task<List<Address>> GetAddress()
        {
            try
            {
                HttpResponseMessage response = await AddressService.addressClient.GetAsync("https://localhost:7030/api/Addresses");
                response.EnsureSuccessStatusCode();
                string address = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Address>>(address);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
        public async Task<HttpStatusCode> PostAddress(Address address)
        {
            HttpResponseMessage response = await AddressService.addressClient.PostAsJsonAsync("https://localhost:7030/api/Addresses", address);
            response.EnsureSuccessStatusCode();
            return response.StatusCode;
        }
        public async Task<HttpStatusCode> PutAddress(Address address, int id)
        {
            HttpResponseMessage response = await addressClient.PutAsJsonAsync("https://localhost:7030/api/Addresses/"+id, address);
            return response.StatusCode;
        }
        public async Task<HttpStatusCode> DeleteAddress(int id)
        {
            HttpResponseMessage response = await addressClient.DeleteAsync("https://localhost:7030/api/Addresses/" + id);
            return response.StatusCode;
        }
    }
}
