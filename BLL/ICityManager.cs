using DTO;
using System.Collections.Generic;

namespace BLL
{
    public interface ICityManager
    {
        List<City> GetCities();

        City GetCity(int id);

        int GetIdCity(int cityCode);
    }

}
