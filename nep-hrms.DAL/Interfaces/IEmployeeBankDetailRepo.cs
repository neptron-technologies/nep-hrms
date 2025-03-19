using nep_hrms.DAL.Models;

namespace nep_hrms.DAL.Interfaces
{
    public interface IEmployeeBankDetailRepo  : IBaseRepo<EmployeeBankDetail>
    {
        Task<EmployeeBankDetail> GetBankDetailsById(int empId);
    }
}
