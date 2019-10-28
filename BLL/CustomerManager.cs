using System;
using DTO;
using DAL;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace BLL
{
    public class CustomerManager
    {

        public CustomerDB CustomerDB { get; }

        public CustomerManager(IConfiguration configuration)
        {
            CustomerDB = new CustomerDB(configuration);
        }

        public List<Customer> GetCustomers()
        {
            return CustomerDB.GetCustomers();
        }

        public Customer GetCustomer(int id)
        {
            return CustomerDB.GetCustomer(id);
        }

        public Customer AddCustomer(Customer customer)
        {
            return CustomerDB.AddCustomer(customer);
        }
        public int UpdateCustomer(Customer customer)
        {
            return CustomerDB.UpdateCustomer(customer);
        }
        public int DeleteCustomer(int id)
        {
            return CustomerDB.DeleteCustomer(id);
        }

    }
}