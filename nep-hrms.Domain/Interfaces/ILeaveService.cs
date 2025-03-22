using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.Domain.Interfaces
{
    public interface ILeaveService
    {
        Task<List<EmpLeave>> GetDataBySql(int EmpId);
        Task<List<EmpLeave>> GetPendingLeavesAsync();
        Task<EmpLeave> ApproveLeaveAsync(int id);
        Task<EmpLeave> RejectLeaveAsync(int id);
        Task<EmpLeave> ApplyLeave(EmpLeave leaveRequest);
        Task<EmpLeaveCancelled> CancelLeave(int leaveId);
        Task<List<Holiday>> GetHolidays();


    }
}
