using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nep_hrms.Domain.Models
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string CreatedBy { get; set; }
        public string Status { get; set; }
        public int EmpId { get; set; }
        public string Fname { get; set; } = string.Empty; 
        // added for ref
                                                          //public List<EmployeeDto>? Employees { get; set; } = new List<EmployeeDto>(); //added
                                                          //public List<EmployeeDTO> Employees { get; set; }
    }
}
