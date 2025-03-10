using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nep_hrms.Domain.Models
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string EmpCode { get; set; } = string.Empty;
        public string Fname { get; set; } = string.Empty;
        public string Lname { get; set; } = string.Empty;
        public DateTime Dob { get; set; }
        public DateTime Doj { get; set; }
        public string? BloodGroup { get; set; }  
        public string Designation { get; set; } = string.Empty;
        public string? Grade { get; set; }  
        public string? BaseLoc { get; set; }  
        public bool? Active { get; set; }  
        public bool? Contractor { get; set; }  
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? CreatedDt { get; set; }  
        public string? UpdatedBy { get; set; }  
        public DateTime? UpdatedDt { get; set; }  
        public int? GradeId { get; set; }  
        public int? EmployeeId { get; set; }  
        public string? company_email { get; set; }  
    }
}
