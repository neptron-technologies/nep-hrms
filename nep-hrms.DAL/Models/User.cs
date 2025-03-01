using System;
using System.Collections.Generic;

namespace nep_hrms.Server.nep_hrms.DAL;

public partial class User
{
    public long Id { get; set; }

    public long EmpId { get; set; }

    public string? Username { get; set; }

    public string? PasswordHash { get; set; }
    public DateTime? CreatedDt { get; set; }
    public DateTime? UpdatedDt { get; set; }
    public string CreatedBy { get; set; }

    public string UpdatedBy { get; set; }

    

    public virtual Employee Emp { get; set; } = null!;

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();

    public UserRole UserRole { get; set; }

    //public List<UserRole> UserRoles { get; set; }
}
