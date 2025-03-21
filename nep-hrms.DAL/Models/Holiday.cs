using System;
using System.Collections.Generic;

namespace nep_hrms.Server.nep_hrms.DAL;
public partial class Holiday
{
    public int Id { get; set; }

    public DateOnly HolidayDate { get; set; }

    public string Reason { get; set; } = null!;

    public bool? Optional { get; set; }
}
