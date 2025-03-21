//using MailKit.Net.Smtp;
//using MailKit.Security;
//using MimeKit;
//using System;
//using System.Threading.Tasks;
//using nep_hrms.DAL.Models;
//using nep_hrms.Domain.Interfaces;
//using nep_hrms.Server.nep_hrms.DAL;
//using Microsoft.Extensions.Options;

//namespace nep_hrms.Domain.Services
using AutoMapper;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MimeKit;
using nep_hrms.DAL.Interfaces;
using nep_hrms.DAL.Models;
using nep_hrms.Domain.Models;
using nep_hrms.Server.nep_hrms.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace nep_hrms.Domain.Services
{
    public class EmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string to, string subject, string body, byte[] attachment = null, string attachmentName = null)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.SenderEmail));
            email.To.Add(new MailboxAddress("", to));
            email.Subject = subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = body };

            if (attachment != null && attachmentName != null)
            {
                bodyBuilder.Attachments.Add(attachmentName, attachment);
            }

            email.Body = bodyBuilder.ToMessageBody();

            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                await smtp.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.Port, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_emailSettings.SenderEmail, _emailSettings.Password);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
            }
        }
    }
}
//public class EmailService : IEmailService
//{
//    private readonly EmailSettings _emailSettings;

//    public EmailService(IOptions<EmailSettings> emailSettings)
//    {
//        _emailSettings = emailSettings.Value;
//    }

//    public async Task SendEmailAsync(string to, string subject, string body, byte[] attachment = null, string attachmentName = null)
//    {
//        var email = new MimeMessage();
//        email.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.SenderEmail));
//        email.To.Add(new MailboxAddress("", to));
//        email.Subject = subject;

//        var bodyBuilder = new BodyBuilder { HtmlBody = body };

//        if (attachment != null && attachmentName != null)
//        {
//            bodyBuilder.Attachments.Add(attachmentName, attachment);
//        }

//        email.Body = bodyBuilder.ToMessageBody();

//        using (var smtp = new SmtpClient())
//        {
//            await smtp.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.Port, SecureSocketOptions.StartTls);
//            await smtp.AuthenticateAsync(_emailSettings.SenderEmail, _emailSettings.Password);
//            await smtp.SendAsync(email);
//            await smtp.DisconnectAsync(true);
//        }

