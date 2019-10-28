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
            var customersDBManager = new CustomerManager(Configuration);

            //Add customer
            Console.WriteLine("--NEW CUSTOMER--");
            var newCustomer = customersDBManager.AddCustomer(new Customer { full_name = "CustomerA", created_at = DateTime.Today, telephone = "045758", login = "CA", password = "test", fk_idCity = 1});
            Console.WriteLine($"ID : {newCustomer.idCustomer} Name : {newCustomer.full_name}");

            //var customers = customersDBManager.GetCustomers();
            ////DISPLAY ALL
            //foreach (var customer in customers)
            //{
            //    Console.WriteLine(customer.ToString());
            //}

            //GET ONE CUSTOMER
            //Console.WriteLine("--GET ONE HOTEL--");
            //var customer1 = customersDBManager.GetCustomer(0);
            //Console.WriteLine(customer1.full_name);

            //DISPLAY ALL
            //foreach (var customer in customers)
            //{
            //    Console.WriteLine(customer.ToString());
            //}

            /*
            //Update hotel
            Console.WriteLine("--UPDATE HOTEL--");
            newCustomer.Name = "Le Rhône";
            customersDBManager.UpdateHotel(newCustomer);
            hotels = customersDBManager.GetAllHotel();
            foreach (var hotel in hotels)
            {
                Console.WriteLine($"ID : {hotel.IdHotel} Name : {hotel.Name}");
            }

            //Delete hotel
            Console.WriteLine("--DELETE HOTEL--");
            customersDBManager.DeleteHotel(12);
            hotels = customersDBManager.GetAllHotel();
            foreach (var hotel in hotels)
            {
                Console.WriteLine($"ID : {hotel.IdHotel} Name : {hotel.Name}");
            }
            */
        }
    }
}
