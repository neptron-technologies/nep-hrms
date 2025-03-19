using nep_hrms.DAL.Interfaces;
using nep_hrms.DAL.Models;

namespace nep_hrms.Domain.Interfaces
{
    public interface IEmployeeBankDetailService  //: IBaseRepo<EmployeeBankDetail>
    {
        Task<EmployeeBankDetail> GetBankDetailsById(int empId);
    }
}
