using nep_hrms.DAL.Models;

namespace nep_hrms.DAL.Interfaces
{
    public interface IPayrollRepo : IBaseRepo<Payroll>
    {
        Task<Payroll?> GetPayrollByEmpId(int empId);
    }
}
