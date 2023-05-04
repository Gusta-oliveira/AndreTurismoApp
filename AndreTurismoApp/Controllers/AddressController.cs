using System.Net;
using AndreTurismoApp.Models;
using AndreTurismoApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private AddressService _addressService;
        public AddressController(AddressService addressService)
        {
            _addressService = addressService;
        }
        [HttpGet]
        public async Task<List<Address>> GetAddress()
        {
            return await _addressService.GetAddress();
        }

        [HttpPost]
        public async Task<HttpStatusCode> PostAddress(Address address)
        {
            return await _addressService.PostAddress(address);
        }
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> PutAddress(Address address, int id)
        {
            return await _addressService.PutAddress(address, id);
        }
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> DeleteAddress(int id)
        {
            return await _addressService.DeleteAddress(id);
        }
    }
}
