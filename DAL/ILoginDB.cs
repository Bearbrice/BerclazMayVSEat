﻿using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public interface ILoginDB
    {
        bool IsLoginValid(Login login);

        List<Login> GetLogins();

        Login GetLogin(int id);

        Login AddLogin(Login login);

        int UpdateLogin(Login login);

        int DeleteLogin(int id);
    }
}
