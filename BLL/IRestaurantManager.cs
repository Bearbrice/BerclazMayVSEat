using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public interface IRestaurantManager
    {

        List<Restaurant> GetRestaurants();

        Restaurant GetRestaurant(int id);

        Restaurant AddRestaurant(Restaurant restaurant);

        int UpdateRestaurant(Restaurant restaurant);

        int DeleteRestaurant(int id);

    }
}