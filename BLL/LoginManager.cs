using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DAL;
using DTO;

namespace BLL
{
    public class LoginManager : ILoginManager
    {
        private ILoginDB LoginDBObject { get; }

        public LoginManager(ILoginDB loginDB)
        {
            LoginDBObject = loginDB;
        }

        public Login AddLogin(Login login, int idCustomer)
        {
            return LoginDBObject.AddLogin(login, idCustomer);
        }

        public bool IsItACustomer(string username)
        {
            return LoginDBObject.IsItACustomer(username);
        }

        public bool IsLoginValid(Login login)
        {
            return LoginDBObject.IsLoginValid(login);
        }

    }
}
