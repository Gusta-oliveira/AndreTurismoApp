using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoApp.Models;
using AndreTurismoApp.Repositories.Interface;
using Dapper;

namespace AndreTurismoApp.Repositories
{
    public class CityRepository : ICityRepository
    {
        private string _conn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\DataBase\reservation.mdf";
        public List<City> GetAll()
        {
            List<City> cities;
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                cities = db.Query<City>(City.GET_ALL).ToList();
            }
            return cities;
        }
        public City Get(int id)
        {
            City city;
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                city = (City)db.Query(City.GET, new { @IdCity = id });
            }
            return city;
        }
        public City Create(City city)
        {
            City c;
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                c = (City)db.ExecuteScalar(City.INSERT, city);
            }
            return c;
        }
        public void Update(City city)
        {
            using (var db = new SqlConnection(_conn))
            {
                db.Execute(City.UPDATE, city);
            }
        }
        public void Delete(int id)
        {
            using (var db = new SqlConnection(_conn))
            {
                db.Execute(City.DELETE, id);
            }
        }
    }
}