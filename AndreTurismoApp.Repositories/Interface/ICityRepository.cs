using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoApp.Models;

namespace AndreTurismoApp.Repositories.Interface
{
    internal interface ICityRepository
    {
        City Create(City city);
        void Update(City city);
        List<City> GetAll();
        void Delete(int id);
    }
}
