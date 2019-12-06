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

        public bool IsLoginValid(Login login)
        {
            return LoginDBObject.IsLoginValid(login);
        }

    }
}
