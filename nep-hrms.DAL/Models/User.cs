using System;
using System.Collections.Generic;

namespace nep_hrms.Server.nep_hrms.DAL;

public partial class User
{
    public long Id { get; set; }

    public int? EmpId { get; set; }

    public string? Username { get; set; }

    public string? PasswordHash { get; set; }
    public required string CreatedBy { get; set; }
    public DateTime? CreatedDt { get; set; }
    public required string UpdatedBy { get; set; }
    public DateTime? UpdatedDt { get; set; }

    public virtual Employee Emp { get; set; } = null!;

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();


    //public ICollection<UserRole> UserRole { get; set; }
    public List<UserRole> Roles { get; set; }
    public List<Permission> Permissions { get; set; }


}