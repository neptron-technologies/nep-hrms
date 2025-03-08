using System;
using System.Collections.Generic;

namespace nep_hrms.Server.nep_hrms.DAL;

public partial class EmployeeJobHistory
{
    public int Id { get; set; }

    public string? JobTitle { get; set; }

    public DateOnly StartDt { get; set; }

    public DateOnly? EndDt { get; set; }

    public string? Loc { get; set; }

    public double? Salary { get; set; }

    public DateTime? CreatedDt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDt { get; set; }

    public string? UpdatedBy { get; set; }

    public int? EmpId { get; set; }

    public virtual Employee? Emp { get; set; }
}