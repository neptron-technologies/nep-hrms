using nep_hrms.Server.nep_hrms.DAL;
using System.ComponentModel.DataAnnotations.Schema;

namespace nep_hrms.DAL.Models
{
    [Table("Payroll")]
    public partial class Payroll
    {
        public int ID { get; set; }
        public int EmpID { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal Bonus { get; set; }
        public decimal Deduction { get; set; }
        public decimal NetSalary { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? PaymentMethod { get; set; }

        public virtual Employee Emp { get; set; }
    }
}
