using Microsoft.EntityFrameworkCore;
using nep_hrms.DAL.Interfaces;
using nep_hrms.DAL.Models;
using nep_hrms.Server.nep_hrms.DAL;


namespace nep_hrms.DAL.Repositories
{
    public class EmployeeBankDetailRepo : BaseRepo<EmployeeBankDetail>, IEmployeeBankDetailRepo
    {
        private readonly IBaseRepo<EmployeeBankDetail> _baseRepo;
        private readonly HrmsDBContext _dbContext;

        public EmployeeBankDetailRepo(HrmsDBContext context, IBaseRepo<EmployeeBankDetail> baseRepo) : base(context)
        {
            _baseRepo = baseRepo;
            _dbContext = context;
        }

        public async Task<EmployeeBankDetail?> GetBankDetailsById(int empId)
        {
            return await _dbContext.EmployeeBankDetail.FirstOrDefaultAsync(p => p.EmpId == empId);
        }
    }
}
    