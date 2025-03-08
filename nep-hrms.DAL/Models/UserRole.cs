using System;
using System.Collections.Generic;

namespace nep_hrms.Server.nep_hrms.DAL;

public partial class UserRole
{
    public long Id { get; set; }

    public long RoleId { get; set; }

    //public User User { get; set; }

    //public Role Role { get; set; }

    public long UserId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? CreatedDt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDt { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual User User { get; set; } = null!;
    public List<RolePermission> RolePermissions { get; set; }

}