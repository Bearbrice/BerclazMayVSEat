using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DAL;
using DTO;

namespace BLL
{
    public class LoginManager : ILoginManager
    {
        private ILoginManager LoginDbObject { get; }

        public LoginManager(ILoginManager loginDB)
        {
            LoginDbObject = loginDB;
        }

        public List<Login> GetLogins()
        {
            return LoginDbObject.GetLogins();
        }

        public Login GetLogin(int id)
        {
            return LoginDbObject.GetLogin(id);
        }

        public Login AddLogin(Login login)
        {
            return LoginDbObject.AddLogin(login);
        }

        public int UpdateLogin(Login login)
        {
            return LoginDbObject.UpdateLogin(login);
        }

        public int DeleteLogin(int id)
        {
            return LoginDbObject.DeleteLogin(id);
        }
    }
}
