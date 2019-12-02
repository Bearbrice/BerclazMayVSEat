using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DAL;
using DTO;

namespace BLL
{
    public class LoginManager : ILoginManager
    {
        public LoginDB LoginDB { get; }

        public LoginManager(IConfiguration configuration)
        {
            LoginDB = new LoginDB(configuration);
        }

        public List<Login> GetLogins()
        {
            return LoginDB.GetLogins();
        }

        public Login GetLogin(int id)
        {
            return LoginDB.GetLogin(id);
        }

        public Login AddLogin(Login login)
        {
            return LoginDB.AddLogin(login);
        }

        public int UpdateLogin(Login login)
        {
            return LoginDB.UpdateLogin(login);
        }

        public int DeleteLogin(int id)
        {
            return LoginDB.DeleteLogin(id);
        }
    }
}
