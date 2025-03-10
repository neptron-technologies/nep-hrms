using Microsoft.EntityFrameworkCore;
using nep_hrms.DAL.Interfaces;
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
        public async Task<List<Attendance>> GetAttendanceByEmpId(int empId)
        {
            var sqlQuery = "SELECT * FROM Attendance WHERE emp_id = {0}";
            return await _dbContext.Attendances.FromSqlRaw(sqlQuery, empId).ToListAsync();
        }

    }
}
