using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DAL;
using DTO;

namespace BLL
{
    public class CityManager : ICityManager
    {

        private ICityDB CityDBObject { get; }

        public CityManager(ICityDB cityDB)
        {
            CityDBObject = cityDB;
        }

        public List<City> GetCities()
        {
            return CityDBObject.GetCities();
        }

        public City GetCity(int id)
        {
            return CityDBObject.GetCity(id);
        }

        public int GetIdCity(int cityCode)
        {
            return CityDBObject.GetIdCity(cityCode);
        }
    }
}