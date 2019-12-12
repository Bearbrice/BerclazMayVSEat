using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public interface ILoginDB
    {
        Login AddLogin(Login login);

        int GetCustomerId(string username);

        bool IsItACustomer(string username);

        bool IsLoginValid(Login login);
    }
}
