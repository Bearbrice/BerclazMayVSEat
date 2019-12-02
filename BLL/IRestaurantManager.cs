using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DAL;

namespace BLL
{
    public interface IRestaurantManager
    {
        //IRestaurantManager RestaurantDB { get; }

        List<Restaurant> GetRestaurants();

        Restaurant GetRestaurant(int id);

        Restaurant AddRestaurant(Restaurant restaurant);

        int UpdateRestaurant(Restaurant restaurant);

        int DeleteRestaurant(int id);
    }
}
