using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nep_hrms.DAL.Interfaces;
using nep_hrms.DAL.Models;
using nep_hrms.Domain.Interfaces;

namespace nep_hrms.Domain.Services
{
    public class EmployeeBankDetailService : IEmployeeBankDetailService
    {
        private readonly IEmployeeBankDetailRepo _employeeBankDetailRepo;

        public EmployeeBankDetailService(IEmployeeBankDetailRepo employeeBankDetailRepo)
        {
            _employeeBankDetailRepo = employeeBankDetailRepo;
        }

        public async Task<EmployeeBankDetail> GetBankDetailsById(int empId)
        {
            return await _employeeBankDetailRepo.GetBankDetailsById(empId);
        }
    }
}
