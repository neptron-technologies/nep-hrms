using nep_hrms.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nep_hrms.DAL.Interfaces
{
    public interface IPayslipRepo
    {
        Task<Payslip?> GetPayslipAsync(int EmpId);
    }
}
