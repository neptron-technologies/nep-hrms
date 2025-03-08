using System;
using System.Collections.Generic;

namespace nep_hrms.Server.nep_hrms.DAL;

public partial class Employee
{
    public int Id { get; set; }

    public string EmpCode { get; set; } = null!;

    public string Fname { get; set; } = null!;

    public string Lname { get; set; } = null!;

    public DateOnly Dob { get; set; }

    public DateOnly Doj { get; set; }

    public string? BloodGroup { get; set; }

    public string Designation { get; set; } = null!;

    public string? Grade { get; set; }

    public string? BaseLoc { get; set; }

    public string CompanyEmail { get; set; }

    public bool? Active { get; set; }

    public bool? Contractor { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? CreatedDt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDt { get; set; }

    public int? GradeId { get; set; }

    public int? EmployeeId { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual ICollection<DesignationHistory> DesignationHistories { get; set; } = new List<DesignationHistory>();

    public virtual ICollection<EmployeeCertification> EmployeeCertifications { get; set; } = new List<EmployeeCertification>();

    public virtual ICollection<EmployeeContactDetail> EmployeeContactDetails { get; set; } = new List<EmployeeContactDetail>();

    public virtual ICollection<EmployeeJobHistory> EmployeeJobHistories { get; set; } = new List<EmployeeJobHistory>();

    public virtual ICollection<EmployeeKyc> EmployeeKycs { get; set; } = new List<EmployeeKyc>();

    public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; } = new List<EmployeeSkill>();

    public virtual EmployeeGrade? GradeNavigation { get; set; }

    public virtual ICollection<LoginLog> LoginLogs { get; set; } = new List<LoginLog>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}