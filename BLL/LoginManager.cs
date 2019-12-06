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

        public List<Login> GetLogins()
        {
            return LoginDBObject.GetLogins();
        }

        public Login GetLogin(int id)
        {
            return LoginDBObject.GetLogin(id);
        }

        public Login AddLogin(Login login)
        {
            return LoginDBObject.AddLogin(login);
        }

        public int UpdateLogin(Login login)
        {
            return LoginDBObject.UpdateLogin(login);
        }

        public int DeleteLogin(int id)
        {
            return LoginDBObject.DeleteLogin(id);
        }

    }
}
