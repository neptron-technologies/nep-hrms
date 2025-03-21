using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace nep_hrms.Server.nep_hrms.DAL;
namespace nep_hrms.DAL.Models;


public class EmailSettings
{
    public string SmtpServer { get; set; } = "sandbox.smtp.mailtrap.io"; //"smtp.neptrontech.com"; // Change this to BigRock SMTP
    public int Port { get; set; } = 465; 
    public string SenderEmail { get; set; } = "26a7604e985c82" ;//"support@neptrontech.com";
    public string SenderName { get; set; } = "NeptronTech HR";
    public string Password { get; set; } = "da2d322934f490"; // " ";
}
