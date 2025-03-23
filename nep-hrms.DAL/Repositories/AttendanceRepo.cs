using Microsoft.EntityFrameworkCore;
using nep_hrms.DAL.Interfaces;
using nep_hrms.DAL.Models;
using nep_hrms.Server.nep_hrms.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nep_hrms.DAL.Repositories
{
    public class AttendanceRepo : BaseRepo<Attendance>, IAttendanceRepo
    {
        private readonly IBaseRepo<Attendance> _baseRepo;
        private readonly HrmsDBContext _dbContext;
        public AttendanceRepo(HrmsDBContext context, IBaseRepo<Attendance> baseRepo) : base(context)
        {
            _baseRepo = baseRepo;
            _dbContext = context;
        }
        //public async Task<List<Attendance>> GetAttendanceByEmpId(int empId, DateTime startDate, DateTime endDate)
        //{
        //    var sqlQuery = "SELECT * FROM Attendance WHERE emp_id = {0} and attendance_date between {1} and {2}";
        //    var attendance = await _dbContext.Attendances.FromSqlRaw(sqlQuery, empId, startDate, endDate).ToListAsync();
        //    return attendance;
        //}
        public async Task<List<Attendance>> GetAttendanceByEmpId(int empId, DateTime startDate, DateTime endDate)
        {
            var sqlQuery = "SELECT * FROM Attendance WHERE emp_id = {0} and attendance_date between {1} and {2}";
            var attendance = await _dbContext.Attendances.FromSqlRaw(sqlQuery, empId, startDate, endDate).ToListAsync();


            var weeklyAttendance = await _dbContext.Attendances
           .Where(a => a.EmpId == empId && a.AttendanceDate >= startDate && a.AttendanceDate <= endDate)
           .OrderByDescending(a => a.AttendanceDate)
           .FirstOrDefaultAsync();

            if (weeklyAttendance != null)
            {

                var statusName = await _dbContext.AttendanceStatuses
                    .Where(s => s.Id == weeklyAttendance.StatusId)
                    .Select(s => s.Status)
                    .FirstOrDefaultAsync();
                weeklyAttendance.Status = new AttendanceStatus { Status = statusName };

            }

            return attendance;
        }

        public async Task<int> GetMonthlyAttendance(int empId)
        {
            DateTime today = DateTime.Now;

            return await _dbContext.Attendances
                .Where(a => a.EmpId == empId &&
                            a.AttendanceDate.HasValue &&
                            a.AttendanceDate.Value.Year == today.Year &&
                            a.AttendanceDate.Value.Month == today.Month)
                .CountAsync();
        }


        //Quaterly attendance
        public async Task<int> GetQuarterlyAttendance(int empId)
        {
            DateTime today = DateTime.Now;
            int currentQuarter = (today.Month - 1) / 3 + 1;
            DateTime startOfQuarter = new DateTime(today.Year, (currentQuarter - 1) * 3 + 1, 1);
            DateTime endOfQuarter = startOfQuarter.AddMonths(3).AddDays(-1);

            return await _dbContext.Attendances
                .Where(a => a.EmpId == empId &&
                            a.AttendanceDate.HasValue &&
                            a.AttendanceDate.Value >= startOfQuarter &&
                            a.AttendanceDate.Value <= endOfQuarter)
                .CountAsync();
        }


    }
}
