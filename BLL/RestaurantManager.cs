using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DAL;
using DTO;

namespace BLL
{
    public class RestaurantManager : IRestaurantManager
    {
        private IRestaurantManager RestaurantDbObject { get; }

        public RestaurantManager(IRestaurantManager restaurantDB)
        {
            RestaurantDbObject = restaurantDB;
        }

        public List<Restaurant> GetRestaurants()
        {
            return RestaurantDbObject.GetRestaurants();
        }

        public Restaurant GetRestaurant(int id)
        {
            return RestaurantDbObject.GetRestaurant(id);
        }

        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            return RestaurantDbObject.AddRestaurant(restaurant);
        }

        public int UpdateRestaurant(Restaurant restaurant)
        {
            return RestaurantDbObject.UpdateRestaurant(restaurant);
        }

        public int DeleteRestaurant(int id)
        {
            return RestaurantDbObject.DeleteRestaurant(id);
        }
    }
}
