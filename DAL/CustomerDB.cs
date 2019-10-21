using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class CustomerDB : ICustomerDB
    {
        public IConfiguration Configuration { get; }
    }
}
