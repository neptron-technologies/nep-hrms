﻿using System;
using System.Collections.Generic;

namespace nep_hrms.Server.nep_hrms.DAL;

public partial class EmployeeSkill
{
    public long Id { get; set; }

    public long? EmpId { get; set; }

    public string Skills { get; set; } = null!;

    public DateTime? CreatedDt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual Employee? Emp { get; set; }
}