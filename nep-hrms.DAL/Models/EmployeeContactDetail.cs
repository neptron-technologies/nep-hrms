using System;
using System.Collections.Generic;

namespace nep_hrms.Server.nep_hrms.DAL;

public partial class EmployeeContactDetail
{
    public long Id { get; set; }

    public long? EmpId { get; set; }

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string? Country { get; set; }

    public string? PinCode { get; set; }

    public string? Mobile { get; set; }

    public DateTime? CreatedDt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual Employee? Emp { get; set; }
}