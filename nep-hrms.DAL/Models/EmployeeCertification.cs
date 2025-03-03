using System;
using System.Collections.Generic;

namespace nep_hrms.Server.nep_hrms.DAL;

public partial class EmployeeCertification
{
    public long Id { get; set; }

    public long? EmpId { get; set; }

    public string? CertificateName { get; set; }

    public string? CertificateId { get; set; }

    public DateTime? IssuedOn { get; set; }

    public DateTime? ValidUpto { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedDt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual Employee? Emp { get; set; }
}