using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nep_hrms.DAL.Models;

namespace nep_hrms.Domain.Interfaces
{
    public interface IEmployeeBankDetailService  //: IBaseRepo<EmployeeBankDetail>
    {
        Task<EmployeeBankDetail> GetBankDetailsById(int empId);
    }
}
