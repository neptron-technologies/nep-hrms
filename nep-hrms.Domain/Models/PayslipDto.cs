using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nep_hrms.Domain.Models
{
    public class PayslipDto
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public decimal Hra { get; set; }
        public decimal ConveyanceAllowance { get; set; }
        public decimal MedicalAllowance { get; set; }
        public decimal OtherAllowance { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal EPF { get; set; }
        public decimal ESI { get; set; }
        public decimal ProfessionalTax { get; set; }
        public decimal TotalDeduction { get; set; }
        public decimal NetSalary { get; set; }
        public DateTime SalaryMonth { get; set; }
        public virtual EmployeeDto? Emp { get; set; }
    }
}
