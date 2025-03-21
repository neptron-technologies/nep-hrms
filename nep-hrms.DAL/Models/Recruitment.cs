using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nep_hrms.DAL.Models;

namespace nep_hrms.DAL.Models
{
    public class Recruitment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string CandidateName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string PositionApplied { get; set; }

        [Required]
        public string Status { get; set; } = "Pending";

        [Required]
        [Range(1, 3)]
        public int InterviewLevel { get; set; } = 1;

        public DateTime? InterviewDate { get; set; }

        [MaxLength(500)]
        public string Feedback { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}


