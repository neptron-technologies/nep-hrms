using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nep_hrms.Domain.Models
{
    public class AttendanceDto
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public DateTime? attendance_date { get; set; }
        public float? hours_filled { get; set; }
        public string? remarks { get; set; }
        public DateTime created_dt { get; set; }
        public string? created_by { get; set; }
        public DateTime? updated_dt { get; set; }
        public string? updated_by { get; set; }
        public string? reviewed_by { get; set; }
        public DateTime? reviewed_dt { get; set; }

    }
}
