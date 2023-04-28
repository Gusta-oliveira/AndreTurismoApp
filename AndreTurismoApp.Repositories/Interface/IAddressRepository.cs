using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoApp.Models;

namespace AndreTurismoApp.Repositories.Interface
{
    public interface IAddressRepository
    {
        Address Create(Address addres);
        List<Address> GetAll();
        void Update(Address address);
        void Delete(int id);
    }
}
