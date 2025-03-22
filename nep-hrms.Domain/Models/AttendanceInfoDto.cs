using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nep_hrms.Domain.Models
{
    public class AttendanceInfoDto
    {
        public int MonthlyAttendance { get; set; }
        public int QuarterlyAttendance { get; set; }
        //  public int Leaves {  get; set; }
        public int? TotalEl { get; set; }
        public int? ElBalance { get; set; } 
        public int? OptionalBal { get; set; } 
        public int? LeaveWithoutPay { get; set; } 

    }
}
