using AndreTurismoApp.Models;
using Newtonsoft.Json;

namespace AndreTurismoApp.Services
{
    public class CityService
    {
        static readonly HttpClient cityClient = new HttpClient();
        public async Task<List<Address>> GetAddress()
        {
            try
            {
                HttpResponseMessage response = await CityService.cityClient.GetAsync("https://localhost:7060/api/Addresses");
                response.EnsureSuccessStatusCode();
                string address = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Address>>(address);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
    }
}
