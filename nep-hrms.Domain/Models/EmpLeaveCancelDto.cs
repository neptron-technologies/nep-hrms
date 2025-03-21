using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nep_hrms.Domain.Models
{
    public class EmpLeaveCancelDto
    {
            public int Id { get; set; }
            public int EmpId { get; set; }
            public string LeaveType { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public int NoOfDays { get; set; }
            public string ApprovedStatus { get; set; }
            public string ApprovedBy { get; set; }
            public string LeaveDesc { get; set; }
            public string ApprovedDesc { get; set; }
            public string CanceledStatus { get; set; } = "Canceled"; // Default Value
            public DateTime CanceledOn { get; set; } = DateTime.Now; // Default Value
        }

    }

