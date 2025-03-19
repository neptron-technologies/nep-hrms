using Microsoft.EntityFrameworkCore;
using nep_hrms.DAL.Interfaces;
using nep_hrms.DAL.Models;
using nep_hrms.Server.nep_hrms.DAL;


namespace nep_hrms.DAL.Repositories
{
    public class PayrollRepo : BaseRepo<Payroll>, IPayrollRepo
    {
        private readonly IBaseRepo<Payroll> _baseRepo;
        private readonly HrmsDBContext _dbContext;

        public PayrollRepo(HrmsDBContext context, IBaseRepo<Payroll> baseRepo) : base(context)
        {
            _baseRepo = baseRepo;
            _dbContext = context;
        }
        public async Task<Payroll?> GetPayrollByEmpId(int empId)
        {
            return await _dbContext.Payroll.FirstOrDefaultAsync(p => p.EmpID == empId);
        }
    }
}
