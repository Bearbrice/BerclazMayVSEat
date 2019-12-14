using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DAL;

namespace BLL
{
    public interface ICustomerManager
    {
        List<Customer> GetCustomers();

        Customer GetCustomer(int id);

        Customer AddCustomer(Customer customer);

        int UpdateCustomer(Customer customer);

        int DeleteCustomer(int id);
    }
}
