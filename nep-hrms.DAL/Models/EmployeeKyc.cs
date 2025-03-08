using System;
using System.Collections.Generic;

namespace nep_hrms.Server.nep_hrms.DAL;

public partial class EmployeeKyc
{
    public int Id { get; set; }

    public string NationalId { get; set; } = null!;

    public string Pancard { get; set; } = null!;

    public string? Passport { get; set; }

    public string? DrivingLicense { get; set; }

    public string? VoterId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? CreatedDt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDt { get; set; }

    public int? EmpId { get; set; }

    public virtual Employee? Emp { get; set; }

    public virtual ICollection<MasterKyc> MasterKycs { get; set; } = new List<MasterKyc>();
}