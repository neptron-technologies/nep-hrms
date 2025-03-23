using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nep_hrms.Domain.Models
{
    public class RecruitmentDTO
    {
        public int Id { get; set; }
        public string CandidateName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PositionApplied { get; set; }
        public string Status { get; set; }
        public int InterviewLevel { get; set; }
        public DateTime? InterviewDate { get; set; }
        public string Feedback { get; set; }
    }
}
