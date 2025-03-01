using System;
using System.Collections.Generic;

namespace nep_hrms.Server.nep_hrms.DAL;

public partial class DesignationHistory
{
    public long Id { get; set; }

    public long? EmpId { get; set; }

    public long DesignationId { get; set; }

    public DateOnly? StartDt { get; set; }

    public DateOnly? EndDt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? CreatedDt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDt { get; set; }

    public virtual Designation Designation { get; set; } = null!;

    public virtual Employee? Emp { get; set; }
}
