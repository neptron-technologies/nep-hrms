using Microsoft.EntityFrameworkCore;
using nep_hrms.DAL.Interfaces;
using nep_hrms.DAL.Models;
using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.DAL.Repositories
{
    public class PayslipRepo : IPayslipRepo
    {
        private readonly HrmsDBContext _dbContext;
        public PayslipRepo(HrmsDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Payslip?> GetPayslipAsync(int EmpId)
        {
            //return await _dbContext.Payslip
            //    .Include(p=>p.EmpId)
            //    .ThenInclude(e=>e.)
            //    .FirstOrDefaultAsync(p => p.EmpId == EmpId);
            return await _dbContext.Payslip
                .Include(p => p.Emp)
                .ThenInclude(e => e.EmployeeBankDetails) // Ensures bank details are loaded
                .FirstOrDefaultAsync(p => p.EmpId == EmpId);
        }
    }
}
