using DTO;
using System.Collections.Generic;

namespace DAL
{
    public interface IRestaurantDB
    {
        List<Restaurant> GetRestaurants(int id);

        Restaurant GetRestaurant(int id);

        Restaurant AddRestaurant(Restaurant restaurant);

        int UpdateRestaurant(Restaurant restaurant);

        int DeleteRestaurant(int id);


    }
}
