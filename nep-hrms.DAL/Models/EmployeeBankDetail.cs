using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.DAL.Models
{
    public class EmployeeBankDetail
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public string UanNo { get; set; }
        public string PfNo { get; set; }
        public string BankName { get; set; }
        public string IfscCode { get; set; }
        public string AccountNo { get; set; }
        public string? Esi { get; set; }
        public string AccountName { get; set; }
        public virtual Employee? Emp { get; set; }

    }
}
