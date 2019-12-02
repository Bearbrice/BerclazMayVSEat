using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DAL;
using DTO;

namespace BLL
{
    public class RestaurantManager : IRestaurantManager
    {
        public RestaurantDB RestaurantDB { get; }

        public RestaurantManager(IConfiguration configuration)
        {
            RestaurantDB = new RestaurantDB(configuration);
        }

        public List<Restaurant> GetRestaurants()
        {
            return RestaurantDB.GetRestaurants();
        }

        public Restaurant GetRestaurant(int id)
        {
            return RestaurantDB.GetRestaurant(id);
        }

        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            return RestaurantDB.AddRestaurant(restaurant);
        }

        public int UpdateRestaurant(Restaurant restaurant)
        {
            return RestaurantDB.UpdateRestaurant(restaurant);
        }

        public int DeleteRestaurant(int id)
        {
            return RestaurantDB.DeleteRestaurant(id);
        }
    }
}
