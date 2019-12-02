using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DAL;
using DTO;

namespace BLL
{
    public class StaffManager : IStaffManager
    {
        public StaffDB StaffDB { get; }

        public StaffManager(IConfiguration configuration)
        {
            StaffDB = new StaffDB(configuration);
        }

        public List<Staff> GetStaffs()
        {
            return StaffDB.GetStaffs();
        }

        public Staff GetStaff(int id)
        {
            return StaffDB.GetStaff(id);
        }

        public Staff AddStaff(Staff staff)
        {
            return StaffDB.AddStaff(staff);
        }

        public int UpdateStaff(Staff staff)
        {
            return StaffDB.UpdateStaff(staff);
        }

        public int DeleteStaff(int id)
        {
            return StaffDB.DeleteStaff(id);
        }
    }
}
