using Microsoft.AspNetCore.Mvc;
using nep_hrms.Domain.Services;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using nep_hrms.Domain.Models;

namespace nep_hrms.Server.API
{
    [Route("api/email")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly EmailService _emailService;

        public EmailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromForm] SendEmailRequest request)
        {
            try
            {
                byte[] fileBytes = null;
                string fileName = null;

                if (request.Attachment != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await request.Attachment.CopyToAsync(memoryStream);
                        fileBytes = memoryStream.ToArray();
                    }
                    fileName = request.Attachment.FileName;
                }

                await _emailService.SendEmailAsync(request.To, request.Subject, request.Body, fileBytes, fileName);
                return Ok(new { message = "Email sent successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

    }
}
