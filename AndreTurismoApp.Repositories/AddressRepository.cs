using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoApp.Models;
using AndreTurismoApp.Repositories.Interface;
using Dapper;

namespace AndreTurismoApp.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private string _conn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\DataBase\reservation.mdf";
        public List<Address> GetAll()
        {
            List<Address> ad;
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                ad = db.Query<Address>(Address.GET_ALL).ToList();
            }
            return ad;
        }
        public Address Get(int id)
        {
            Address ad;
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                ad = (Address)db.Query(Address.GET, new { @IdAddress = id });
            }
            return ad;
        }
        public Address Create(Address ad)
        {
            Address add;
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                add = (Address)db.ExecuteScalar(Address.INSERT, ad);
            }
            return add;
        }
        public void Update(Address ad)
        {
            using (var db = new SqlConnection(_conn))
            {
                db.Execute(Address.UPDATE, ad);
            }
        }
        public void Delete(int id)
        {
            using (var db = new SqlConnection(_conn))
            {
                db.Execute(Address.DELETE, id);
            }
        }
    }
}
