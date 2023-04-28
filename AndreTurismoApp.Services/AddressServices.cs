using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoApp.Models;
using AndreTurismoApp.Repositories;

namespace AndreTurismoApp.Services
{
    public class AddressServices
    {
        private readonly AddressRepository _addressRepository;
        public AddressServices(AddressRepository cityService)
        {
            _addressRepository = cityService;
        }

        public Address Insert(Address address)
        {
            return _addressRepository.Create(address);
        }
        public List<Address> GetAll()
        {
            return _addressRepository.GetAll();
        }
        public Address Get(int id)
        {
            return _addressRepository.Get(id);
        }

        public bool Update(int id)
        {
            bool status;
            var city = _addressRepository.Get(id);
            try
            {
                _addressRepository.Update(city);

                status = true;
            }
            catch (Exception)
            {
                status = false;
                throw;
            }
            return status;
        }
        public bool Delete(int id)
        {
            bool status = false;
            try
            {
                _addressRepository.Delete(id);
                status = true;
            }
            catch
            {
                status = false;
                throw;
            }
            return status;
        }
    }
}
