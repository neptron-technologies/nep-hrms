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

        public string? UanNo { get; set; }
        public string? PfNo { get; set; }
        public string? BankName { get; set; }
        public string? IfscCode { get; set; }
        public string? AccountNo { get; set; }
        public string? EsiNo { get; set; }
        public string? AccountName { get; set; }
    }
}
