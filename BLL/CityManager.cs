using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DAL;
using DTO;

namespace BLL
{
    public class CityManager : ICityManager
    {
        private ICityManager CityDbObject { get; }

        public CityManager(ICityManager cityDB)
        {
            CityDbObject = cityDB;
        }

        public List<City> GetCities()
        {
            return CityDbObject.GetCities();
        }

        //public City GetCity(int id)
        //{
        //    return CityDB.GetCity(id);
        //}

        //public City AddCity(City city)
        //{
        //    return CityDB.AddCity(city);
        //}

        //public int UpdateCity(City city)
        //{
        //    return CityDB.UpdateCity(city);
        //}

        //public int DeleteCity(int id)
        //{
        //    return CityDB.DeleteCity(id);
        //}
    }
}
