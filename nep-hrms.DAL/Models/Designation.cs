using System;
using System.Collections.Generic;

namespace nep_hrms.Server.nep_hrms.DAL;

public partial class Designation
{
    public long Id { get; set; }

    public string DesigName { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime? CreatedDt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDt { get; set; }

    public virtual ICollection<DesignationHistory> DesignationHistories { get; set; } = new List<DesignationHistory>();
}