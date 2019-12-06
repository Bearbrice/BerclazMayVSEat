using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DAL;
using DTO;

namespace BLL
{
    public class RestaurantManager : IRestaurantManager
    {
        private IRestaurantDB RestaurantDBObject { get; }

        public RestaurantManager(IRestaurantDB restaurantDB)
        {
            RestaurantDBObject = restaurantDB;
        }

        public List<Restaurant> GetRestaurants(int id)
        {
            return RestaurantDBObject.GetRestaurants(id);
        }

        public Restaurant GetRestaurant(int id)
        {
            return RestaurantDBObject.GetRestaurant(id);
        }

        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            return RestaurantDBObject.AddRestaurant(restaurant);
        }

        public int UpdateRestaurant(Restaurant restaurant)
        {
            return RestaurantDBObject.UpdateRestaurant(restaurant);
        }

        public int DeleteRestaurant(int id)
        {
            return RestaurantDBObject.DeleteRestaurant(id);
        }

    }
}
