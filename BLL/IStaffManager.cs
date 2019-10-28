using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DAL;

namespace BLL
{
    public interface IStaffManager
    {
        IStaffManager StaffDB { get; }

        List<Staff> GetStaffs();

        Staff GetStaff(int id);

        Staff AddStaff(Staff staff);

        int UpdateStaff(Staff staff);

        int DeleteCity(int id);
    }
}
