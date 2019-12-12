using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DAL;
using DTO;

namespace BLL
{
    public class StaffManager : IStaffManager
    {
        private IStaffManager StaffDbObject { get; }

        public StaffManager(IStaffManager staffDB)
        {
            StaffDbObject = staffDB;
        }

        public List<Staff> GetStaffsByCity(int idCity)
        {
            return StaffDbObject.GetStaffsByCity(idCity);
        }

        public List<Staff> GetStaffs()
        {
            return StaffDbObject.GetStaffs();
        }

        public Staff GetStaff(int id)
        {
            return StaffDbObject.GetStaff(id);
        }

        public Staff AddStaff(Staff staff)
        {
            return StaffDbObject.AddStaff(staff);
        }

        public int UpdateStaff(Staff staff)
        {
            return StaffDbObject.UpdateStaff(staff);
        }

        public int DeleteStaff(int id)
        {
            return StaffDbObject.DeleteStaff(id);
        }
    }
}
