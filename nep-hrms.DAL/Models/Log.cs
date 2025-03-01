using System;
using System.Collections.Generic;

namespace nep_hrms.Server.nep_hrms.DAL;

public partial class Log
{
    public long Id { get; set; }

    public long? UserId { get; set; }

    public string? Remarks { get; set; }

    public DateTime LogDateTime { get; set; }

    public virtual User? User { get; set; }
}
