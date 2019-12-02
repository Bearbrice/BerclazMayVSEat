using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DAL;

namespace BLL
{
    public interface ILoginManager
    {
        //ILoginDB LoginDB { get; }

        List<Login> GetLogins();

        Login GetLogin(int id);

        Login AddLogin(Login login);

        int UpdateLogin(Login login);

        int DeleteLogin(int id);
    }
}
