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
    public class PayslipRepo : IPayslipRepo
    {
        private readonly HrmsDBContext _dbContext;
        public PayslipRepo(HrmsDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Payslip?> GetPayslipAsync(int EmpId)
        {
            return await _dbContext.Payslip.FirstOrDefaultAsync(p => p.EmpId == EmpId);
        }
    }
}
