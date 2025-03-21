using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.DAL.Interfaces
{
    public  interface ILeaveRepo :IBaseRepo<EmpLeave>
    {
        Task<List<EmpLeave>> GetPendingLeavesAsync();
        Task<List<EmpLeave>> GetLeaveByEmpId(int empId);
        Task<EmpLeave> AddLeave(EmpLeave leaverequest);
        Task<EmpLeave> CancelLeave(int leaveId);
        

        Task<EmpLeaveBalance> GetByEmpIdAsync(int empid);
    }
}
