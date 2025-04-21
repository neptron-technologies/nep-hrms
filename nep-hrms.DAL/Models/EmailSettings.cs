using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nep_hrms.DAL.Models
{
    public class EmailSettings
    {
        public string SmtpServer { get; set; } = "sandbox.smtp.mailtrap.io"; // Testing SMTP (Mailtrap)
        public int Port { get; set; } = 587; // Use 587 for STARTTLS
        public string SenderEmail { get; set; } = "suraj.s@neptrontech.com"; // Your Mailtrap username
        public string SenderName { get; set; } = "NeptronTech HR";
        public string Password { get; set; } = "m9fk!5b33"; // Your Mailtrap password
    }
}
