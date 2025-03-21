using System;
using System.Collections.Generic;


namespace nep_hrms.Server.nep_hrms.DAL;
public partial class EmpLeaveBalance
{
    public int Id { get; set; }

    public int EmpId { get; set; }

    public int? EarnedLeavesForFy { get; set; }

    public int? ElBalance { get; set; }

    public int? LeaveWithoutPay { get; set; }

    public int? OptionalBal { get; set; }

    public int? OptionalForFy { get; set; }
}
