using nep_hrms.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nep_hrms.Domain.Interfaces
{
    public interface IPayrollService
    {
        Task<Payroll> GetPayrollByEmpId(int empId);
    }
}
