using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DAL;

namespace BLL
{
    public interface ICityManager
    {
        //ICityDB CityDB { get; }

        List<City> GetCities();

        //City GetCity(int id);

        //City AddCity(City city);

        //int UpdateCity(City city);

        //int DeleteCity(int id);
    }
}
