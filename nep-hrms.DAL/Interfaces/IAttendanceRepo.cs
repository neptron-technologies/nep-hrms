using nep_hrms.Server.nep_hrms.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nep_hrms.DAL.Interfaces
{
    public interface IAttendanceRepo : IBaseRepo<Attendance>
    {
        Task<List<Attendance>> GetAttendanceByEmpId(int empId);
    }
}
