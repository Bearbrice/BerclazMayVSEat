using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public interface IDishDB
    {
        List<Dish> GetDishes(int id);

        Dish GetDish(int id);

        Dish AddDish(Dish dish);

        int UpdateDish(Dish dish);

        int DeleteDish(int id);
    }
}
