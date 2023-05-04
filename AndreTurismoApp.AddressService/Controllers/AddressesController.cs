using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreTurismoApp.AddressService.Data;
using AndreTurismoApp.Models;
using AndreTurismoApp.Services;
using AndreTurismoApp.Models.DTO;

namespace AndreTurismoApp.AddressService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly PostOfficesService _postOfficesService;
        private readonly AndreTurismoAppAddressServiceContext _context;

        public AddressesController(AndreTurismoAppAddressServiceContext context, PostOfficesService postOfficesService)
        {
            _postOfficesService = postOfficesService;
            _context = context;
        }
        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddress()
        {
            if (_context.Address == null)
            {
                return NotFound();
            }
            return await _context.Address.Include(a => a.City).ToListAsync();
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
            if (_context.Address == null)
            {
                return NotFound();
            }
            var listAddress = await _context.Address.Include(x => x.City).ToListAsync();

            var address = listAddress.FirstOrDefault(x => x.City.Id == id);

            if (address == null)
            {
                return NotFound();
            }
            return address;
        }

        // PUT: api/Addresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(int id, Address address)
        {
            //if (id != address.Id)
            //{
            //    return BadRequest();
            //}

            _context.Entry(address).State = EntityState.Modified;

            try
            {
                var number = address.Number;
                var post = _postOfficesService.GetAddress(address.CEP).Result;

                address.Street = post.Street;
                address.Neighborhood = post.Neighborhood;
                address.City.Description = post.City;

                _context.Address.Update(address);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!AddressExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //}
                throw;
            }

            return NoContent();
        }

        // POST: api/Addresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Address>> PostAddress(Address address)
        //{
        //    if (_context.Address == null)
        //    {
        //        return Problem("Entity set 'AndreTurismoAppAddressServiceContext.Address'  is null.");
        //    }
        //    //Chamar o servico de consulta de endereco ViaCEP
        //    AddressDTO addreesDto = _postOfficesService.GetAddress(address.CEP).Result;
        //    var addressComplete = new Address(addreesDto);
        //    _context.Address.Add(addressComplete);

        //    await _context.SaveChangesAsync();

        //    return addressComplete;
        //}
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(Address address)
        {
            if (_context.Address == null)
            {
                return Problem("Entity set 'AndreTurismoAppAddressServiceContext.Address'  is null.");
            }

            var post = _postOfficesService.GetAddress(address.CEP).Result;
            var number = address.Number;

            address.CEP = post.CEP;
            address.Street = post.Street;
            address.Number = number;
            address.Neighborhood = post.Neighborhood;
            address.City.Description = post.City;



            _context.Address.Add(address);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddress", new { id = address.Id }, address);
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            if (_context.Address == null)
            {
                return NotFound();
            }
            var address = await _context.Address.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            _context.Address.Remove(address);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddressExists(int id)
        {
            return (_context.Address?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
