
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nep_hrms.Domain.Models
{
    public class AttendanceSummaryDto
    {
        public int MonthlyAttendance { get; set; }
        public int QuarterlyAttendance { get; set; }
        // public int LeaveBalance { get; set; }
    }
}
