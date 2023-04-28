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
    public class CityServices
    { 
        private readonly CityRepository _cityRepository;
        public CityServices(CityRepository cityService)
        {
            _cityRepository = cityService;
        }

        public City Insert(City city)
        {
            return _cityRepository.Create(city);
        }
        public List<City> GetAll()
        {
            return _cityRepository.GetAll();
        }
        public City Get(int id)
        {
            return _cityRepository.Get(id);
        }

        public bool Update(int id)
        {
            bool status;
            var city =_cityRepository.Get(id);
            try
            { 
                _cityRepository.Update(city);

                status = true;
            }
            catch(Exception)
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
                _cityRepository.Delete(id);
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
