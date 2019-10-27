using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public interface IDishDB
    {
        IConfiguration Configuration { get; }

        List<Dish> GetDishes();

        Dish GetDish(int id);

        Dish AddDish(Dish hotel);

        int UpdateDish(Dish hotel);

        int DeleteDish(int id);
    }
}
