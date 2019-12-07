using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public interface ILoginManager
    {
        bool IsItACustomer(string username);

        bool IsLoginValid(Login login);
    }
}