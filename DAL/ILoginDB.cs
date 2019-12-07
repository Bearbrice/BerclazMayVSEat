using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public interface ILoginDB
    {
        bool IsItACustomer(string username);

        bool IsLoginValid(Login login);
    }
}
