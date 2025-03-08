using System;
using System.Collections.Generic;

namespace nep_hrms.Server.nep_hrms.DAL;

public partial class Attendance
{
    public int Id { get; set; }

    public DateOnly? AttendanceDate { get; set; }

    public double? HoursFilled { get; set; }

    public string? Remarks { get; set; }

    public DateTime? CreatedDt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDt { get; set; }

    public string? UpdatedBy { get; set; }

    public string? ReviewedBy { get; set; }

    public DateTime? ReviewedDt { get; set; }

    public int? EmpId { get; set; }

    public virtual Employee? Emp { get; set; }
}