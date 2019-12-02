using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL
{
    public interface ICityDB
    {
        //IConfiguration Configuration { get; }

        List<City> GetCities();

        //City GetCity(int id);

        //City AddCity(City city);

        //int UpdateCity(City city);

        //int DeleteCity(int id);
    }
}
