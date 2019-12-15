using DTO;
using System.Collections.Generic;

namespace BLL
{
    public interface IDishManager
    {
        List<Dish> GetDishes(int id);

        Dish GetDish(int id);

        Dish AddDish(Dish dish);

        int UpdateDish(Dish dish);

        int DeleteDish(int id);

    }
}