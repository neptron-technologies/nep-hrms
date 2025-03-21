using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.DAL.Models
{
    public class Project
    {
        public int Id { get; set; }

        //[Required]
        //[Column(TypeName = "nvarchar(255)")]
        public string ProjectName { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        //[Required]
        //[Column(TypeName = "nvarchar(50)")]
        public string Status { get; set; } = "Active";  // Default status

        //[Required]
        public string CreatedBy { get; set; } = null!;

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDt { get; set; } = DateTime.UtcNow;  // Default to current date

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDt { get; set; }

        // Many-to-Many Relationship with EmployeeProject
        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; } = new HashSet<EmployeeProject>();
    }
}
