using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public class StaffManager : IStaffManager
    {
        private IStaffDB StaffDBObject { get; }

        public StaffManager(IStaffDB staffDB)
        {
            StaffDBObject = staffDB;
        }

        public List<Staff> GetStaffsByCity(int idCity)
        {
            return StaffDBObject.GetStaffsByCity(idCity);
        }

        public List<Staff> GetStaffs()
        {
            return StaffDBObject.GetStaffs();
        }

        public Staff GetStaff(int id)
        {
            return StaffDBObject.GetStaff(id);
        }

        public Staff AddStaff(Staff staff)
        {
            return StaffDBObject.AddStaff(staff);
        }

        public int UpdateStaff(Staff staff)
        {
            return StaffDBObject.UpdateStaff(staff);
        }

        public int DeleteStaff(int id)
        {
            return StaffDBObject.DeleteStaff(id);
        }
    }
}
