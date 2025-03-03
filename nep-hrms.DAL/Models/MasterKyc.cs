using System;
using System.Collections.Generic;

namespace nep_hrms.Server.nep_hrms.DAL;

public partial class MasterKyc
{
    public long Id { get; set; }

    public string? KycType { get; set; }

    public string? VerifiedBy { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? CreatedDt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDt { get; set; }

    public long EmpkycId { get; set; }

    public virtual EmployeeKyc Empkyc { get; set; } = null!;
}