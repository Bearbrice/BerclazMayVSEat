using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public interface IStaffDB
    {
        //IConfiguration Configuration { get; }

        List<Staff> GetStaffs();

        Staff GetStaff(int id);

        Staff AddStaff(Staff staff);

        int UpdateStaff(Staff staff);

        int DeleteStaff(int id);


    }
}
