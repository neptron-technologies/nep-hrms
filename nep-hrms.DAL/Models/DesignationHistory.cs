using System;
using System.Collections.Generic;

namespace nep_hrms.Server.nep_hrms.DAL;

public partial class DesignationHistory
{
    public int Id { get; set; }

    public DateOnly? StartDt { get; set; }

    public DateOnly? EndDt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? CreatedDt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDt { get; set; }

    public int? EmpId { get; set; }

    public int? DesignationId { get; set; }

    public virtual Designation? Designation { get; set; }

    public virtual Employee? Emp { get; set; }
}