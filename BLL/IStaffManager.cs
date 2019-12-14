﻿using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DAL;

namespace BLL
{
    public interface IStaffManager
    {
        List<Staff> GetStaffsByCity(int idCity);

        List<Staff> GetStaffs();

        Staff GetStaff(int id);

        Staff AddStaff(Staff staff);

        int UpdateStaff(Staff staff);

        int DeleteStaff(int id);
    }
}
