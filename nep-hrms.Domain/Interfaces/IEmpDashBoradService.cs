using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nep_hrms.Domain.Models;


namespace nep_hrms.Domain.Interfaces
{
    public interface IEmpDashBoradService
    { 
        Task<AttendanceInfoDto> GetAttendanceInfo(int empId);


    }
}
