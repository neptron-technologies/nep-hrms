using System;
using System.Collections.Generic;

namespace nep_hrms.Server.nep_hrms.DAL;

public partial class EmployeeGrade
{
    public long Id { get; set; }

    public string? Grade { get; set; }

    public string? Remarks { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
