using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using nep_hrms.DAL.Interfaces;
using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.DAL.Repositories
{
    public class LeaveRepo : BaseRepo<EmpLeave>, ILeaveRepo
    {
        

        private readonly IBaseRepo<EmpLeave> _baseRepo;
       
        private readonly HrmsDBContext _dbContext;
        public LeaveRepo(HrmsDBContext context, IBaseRepo<EmpLeave> baseRepo) : base(context)
        {
            
            _baseRepo = baseRepo;
            _dbContext = context;
            
        }

        public async Task<List<EmpLeave>> GetLeaveByEmpId(int empId)
        {
            var sqlQuery = "SELECT * FROM EmpLeave WHERE empid = {0}";
            return await _dbContext.EmpLeave.FromSqlRaw(sqlQuery, empId).ToListAsync();
        }
        public async Task<EmpLeave> AddLeave(EmpLeave leave)
        {
            await _dbContext.EmpLeave.AddAsync(leave);
            await _dbContext.SaveChangesAsync();
            return leave;
        }

        public async Task<EmpLeaveBalance> GetByEmpIdAsync(int empid)
        {
            return await _dbContext.EmpLeaveBalance.FirstOrDefaultAsync(b => b.EmpId == empid);
        }

        public async Task<EmpLeave> CancelLeave(int leaveId)
        {
            return  await _dbContext.EmpLeave.FindAsync(leaveId);

        }

        public async Task<List<EmpLeave>> GetPendingLeavesAsync()
        {
            return await _dbContext.EmpLeave
                .Where(l => l.ApprovedStatus == "Pending")
                .ToListAsync();
        }


    }
}
