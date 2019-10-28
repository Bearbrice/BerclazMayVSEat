using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class StaffDB : IRestaurantDB
    {
        public IConfiguration Configuration { get; }

        public StaffDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        
    }
}
