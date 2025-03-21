using nep_hrms.DAL.Interfaces;
using nep_hrms.DAL.Models;
using nep_hrms.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nep_hrms.Domain.Services
{
    public class PayrollService : IPayrollService
    {
        private readonly IPayrollRepo _payrollRepo;

        public PayrollService(IPayrollRepo payrollRepo)
        {
            _payrollRepo = payrollRepo;
        }

        public async Task<Payroll?> GetPayrollByEmpId(int empId)
        {
            return await _payrollRepo.GetPayrollByEmpId(empId);
        }
    }
}
