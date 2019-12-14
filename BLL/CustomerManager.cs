using System;
using DTO;
using DAL;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace BLL
{
    public class CustomerManager : ICustomerManager
    {
        private ICustomerDB CustomerDbObject { get; }

        public CustomerManager(ICustomerDB customerDB)
        {
            CustomerDbObject = customerDB;
        }

        public List<Customer> GetCustomers()
        {
            return CustomerDbObject.GetCustomers();
        }

        public Customer GetCustomer(int id)
        {
            return CustomerDbObject.GetCustomer(id);
        }

        public Customer AddCustomer(Customer customer)
        {
            return CustomerDbObject.AddCustomer(customer);
        }
        public int UpdateCustomer(Customer customer)
        {
            return CustomerDbObject.UpdateCustomer(customer);
        }
        public int DeleteCustomer(int id)
        {
            return CustomerDbObject.DeleteCustomer(id);
        }

    }
}