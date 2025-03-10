using System;
using System.Collections.Generic;

namespace nep_hrms.Server.nep_hrms.DAL;

public partial class RolePermission
{
    public long Id { get; set; }

    public long RoleId { get; set; }

    //public Role Role { get; set; }

    public long PermissionId { get; set; }

    public Permission Permission { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDt { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public DateTime UpdatedDt { get; set; }

    //public virtual Permission Permission { get; set; } = null!;
    // now done public virtual List<Permission> Permissions { get; set; } = null!;
    public virtual Role Role { get; set; } = null!;
}