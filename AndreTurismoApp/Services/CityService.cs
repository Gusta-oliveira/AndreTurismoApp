﻿using AndreTurismoApp.Models;
using Newtonsoft.Json;
using System.Net;

namespace AndreTurismoApp.Services
{
    public class CityService
    {
        static readonly HttpClient cities = new HttpClient();


        public async Task<List<City>> GetCity()
        {
            try
            {
                HttpResponseMessage response = await cities.GetAsync("https://localhost:7227/api/Cities");
                response.EnsureSuccessStatusCode();
                string ender = await response.Content.ReadAsStringAsync();
                var end = JsonConvert.DeserializeObject<List<City>>(ender);
                return end;
            }
            catch (HttpRequestException e)
            {
                return new List<City>();
            }
        }

        public async Task<City> GetCityById(int id)
        {
            try
            {
                HttpResponseMessage response = await cities.GetAsync("https://localhost:7227/api/Cities/" + id);
                response.EnsureSuccessStatusCode();
                string ender = await response.Content.ReadAsStringAsync();
                var end = JsonConvert.DeserializeObject<City>(ender);
                return end;
            }
            catch (HttpRequestException e)
            {
                return null;
            }
        }

        public async Task<HttpStatusCode> PostCity(City city)
        {
            HttpResponseMessage response = await cities.PostAsJsonAsync("https://localhost:7227/api/Cities", city);
            return response.StatusCode;
        }

        public async Task<HttpStatusCode> PutCity(City city)
        {
            HttpResponseMessage response = await cities.PutAsJsonAsync("https://localhost:7227/api/Cities", city);
            return response.StatusCode;
        }


        public async Task<HttpStatusCode> DeleteCity(int id)
        {
            HttpResponseMessage response = await cities.DeleteAsync("https://localhost:7227/api/Cities/" + id);
            return response.StatusCode;
        }

    }
}