using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class RestaurantDB : IRestaurantDB
    {
        public IConfiguration Configuration { get; }

        public RestaurantDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        
    }
}
