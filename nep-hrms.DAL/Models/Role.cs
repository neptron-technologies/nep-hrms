using System;
using System.Collections.Generic;

namespace nep_hrms.Server.nep_hrms.DAL;

public partial class Role
{
    public long Id { get; set; }

    public string? RoleName { get; set; }

    public string? Comment { get; set; }

    //public List<UserRole> UserRoles { get; set; }

    //public List<RolePermission> RolePermissions {  get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? CreatedDt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDt { get; set; }

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

    public virtual UserRole? UserRole { get; set; }
}
