using System;
using System.Collections.Generic;
using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.DAL.Models;

public partial class AttendanceStatus
{
    public int Id { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
}
