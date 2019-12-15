using DTO;
using System.Collections.Generic;

namespace DAL
{
    public interface IStaffDB
    {
        List<Staff> GetStaffsByCity(int idCity);

        List<Staff> GetStaffs();

        Staff GetStaff(int id);

        Staff AddStaff(Staff staff);

        int UpdateStaff(Staff staff);

        int DeleteStaff(int id);


    }
}
