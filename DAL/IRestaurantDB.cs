using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public interface IRestaurantDB
    {
        IConfiguration Configuration { get; }

        
    }
}
