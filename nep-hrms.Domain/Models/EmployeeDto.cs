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
        public string fname { get; set; }
        public string lname { get; set; } 
        public string emp_code { get; set; } 
        public DateOnly dob { get; set; }
        public DateOnly doj { get; set; }
        public required string designation { get; set; } 

        //[Required(ErrorMessage = "Company email is required")] //added
        //[EmailAddress(ErrorMessage = "Invalid email format")] //added
        public string company_email { get; set; } 

        public string created_by { get; set; }

        public int? EmployeeId { get; set; }

        // Constructor to handle NULL values
        //public EmployeeDto()
        //{
        //    BloodGroup = BloodGroup ?? "Not Provided";
        //    Grade = Grade ?? "N/A";
        //    BaseLoc = BaseLoc ?? "Unknown";
        //    UpdatedBy = UpdatedBy ?? "Not Updated";
        //    UpdatedDt = UpdatedDt ?? DateTime.MinValue;
        //    EmployeeId = EmployeeId ?? 0;
        //    company_email = company_email ?? "No Email";
        //}

    }
}
