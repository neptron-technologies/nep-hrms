using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nep_hrms.Domain.Models
{
    public class EmpLeaveDto
    {
        public int Id { get; set; }

        public int EmpId { get; set; }

        public string LeaveType { get; set; } = null!;

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public DateTime? AppliedOn { get; set; }

        public int NoOfDays { get; set; }

        public string? ApprovedStatus { get; set; }

        public string? ApprovedBy { get; set; }

        public string? LeaveDesc { get; set; }

        public string? ApprovedDesc { get; set; }

        public string? CanceledStatus { get; set; }

        public DateTime? CanceledOn { get; set; }
    }
}
