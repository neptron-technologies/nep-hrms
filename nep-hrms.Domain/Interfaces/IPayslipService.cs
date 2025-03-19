using nep_hrms.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nep_hrms.Domain.Interfaces
{
    public interface IPayslipService
    {
       Task<PayslipDto?> GetPayslipAsync(int EmpId);

        //Task<PayslipDto> GeneratePayslip(int EmpId, DateTime SalaryMonth);

    }
}
