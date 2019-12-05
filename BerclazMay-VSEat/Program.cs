using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using BLL;
using DTO;

namespace BerclazMay_VSEat
{
    class Program
    {

        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .Build();

        static void Main(string[] args)
        {
            /* 
             * -- CUSTOMER TEST --
             */
            //var customersDBManager = new CustomerManager(Configuration);

            ////Add customer
            //Console.WriteLine("--NEW CUSTOMER--");
            ////var newCustomer = customersDBManager.AddCustomer(new Customer { full_name = "CustomerA", created_at = DateTime.Today, telephone = "045758", login = "CA", password = "test", fk_idCity = 1 });
            ////Console.WriteLine($"ID : {newCustomer.idCustomer} Name : {newCustomer.full_name}");

            ////var customers = customersDBManager.GetCustomers();
           
            ////DISPLAY ALL
            ////foreach (var customer in customers)
            //{
            //   // Console.WriteLine(customer.ToString());
            //}

            
        }
    }
}
