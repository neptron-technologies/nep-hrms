using Microsoft.VisualBasic;
using nep_hrms.DAL.Interfaces;
using nep_hrms.DAL.Models;
using nep_hrms.Domain.Interfaces;
using nep_hrms.Domain.Models;
using nep_hrms.Server.nep_hrms.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace nep_hrms.Domain.Services
{
    public class PayslipService : IPayslipService
    {
        //private readonly HrmsDBContext _dbContext;
        private readonly IPayslipRepo _payslipRepo;

        public PayslipService(IPayslipRepo payslipRepo)
        {
            _payslipRepo = payslipRepo;
        }

        public async Task<PayslipDto?> GetPayslipAsync(int EmpId)
        {
            var payslip = await _payslipRepo.GetPayslipAsync(EmpId);

            if (payslip == null)
                return null;

            decimal grossSalary = payslip.GrossSalary;
            decimal epf = CalculateEPF(grossSalary);
            decimal esi = CalculateESI(grossSalary);
            decimal professionalTax = CalculateProfessionalTax(grossSalary);
            decimal totalDeduction = epf + esi + professionalTax;
            decimal netSalary = grossSalary - totalDeduction;


            return new PayslipDto
            {
                Id = payslip.Id,
                EmpId = payslip.EmpId,
                Hra = payslip.Hra,
                ConveyanceAllowance = payslip.ConveyanceAllowance,
                MedicalAllowance = payslip.MedicalAllowance,
                OtherAllowance = payslip.OtherAllowance,
                GrossSalary = payslip.GrossSalary,
                EPF = epf,
                ESI = esi,
                ProfessionalTax = professionalTax,
                TotalDeduction = totalDeduction,
                NetSalary = netSalary,
                SalaryMonth = payslip.SalaryMonth
            };
        }
        private decimal CalculateEPF(decimal grossSalary)
        {
            return grossSalary * 0.12m;
        }
        private decimal CalculateESI(decimal grossSalary)
        {
            if (grossSalary > 21000)
                return 0;

            return grossSalary * 0.0075m;
        }
        private decimal CalculateProfessionalTax(decimal grossSalary)
        {
            if (grossSalary < 10000)
                return 0;
            else if (grossSalary < 15000)
                return 200;
            else
                return 500;
        }

    }
}
