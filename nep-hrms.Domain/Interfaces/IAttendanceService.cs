using nep_hrms.DAL.Interfaces;
using nep_hrms.Domain.Models;
using nep_hrms.Server.nep_hrms.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nep_hrms.Domain.Interfaces
{
    public interface IAttendanceService
    {
        //public Task<List<Attendance>> GetAllAsync();
        //public Task<Attendance?> GetByIdAsync(int id);
        Task<List<Attendance>> GetDataBySql(int EmpId);
        Task<Attendance> AddAsync(Attendance attendance);
        Task<AttendanceDto> AddAsync(AttendanceDto attendanceDto);
        Task UpdateAsync(Attendance attendance);
        Task DeleteAsync(int id);
        // Task<IEnumerable<Attendance>> GetByEmployeeIdAsync(long empId);
        //req   public Task<AttendanceDto> AddAsync(AttendanceDto attendanceDto);
        //Task<Attendance?> UpdateAsync(long id, Attendance attendance);
        //Task<bool> DeleteAsync(long id);
        //req  public Task<List<Attendance>> GetDataBySql(int EmpId);
    }
}
