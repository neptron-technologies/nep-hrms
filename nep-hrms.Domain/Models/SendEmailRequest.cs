using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;


namespace nep_hrms.Domain.Models
{
    public class SendEmailRequest
    {
        [Required]
        public string To { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }

        public IFormFile Attachment { get; set; }
    }
}
