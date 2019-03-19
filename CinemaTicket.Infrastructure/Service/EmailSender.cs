using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;

namespace CinemaTickets.Infrastructure.Service
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;
        private readonly IHostingEnvironment _hostingEnvironment;

        public EmailSender(EmailSettings emailSettings, IHostingEnvironment hostingEnvironment)
        {
            _emailSettings = emailSettings;
            _hostingEnvironment = hostingEnvironment;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {

            Execute(email, subject, message);
            return Task.FromResult(0);
        }

        private void Execute(string email, string subject, string message)
        {
            var toEmail = string.IsNullOrEmpty(email)
                             ? _emailSettings.ToEmail
                             : email;

            MailMessage mail = new MailMessage()
            {
                From = new MailAddress(_emailSettings.UsernameEmail, "CinemaTickets")
            };
            mail.To.Add(new MailAddress(toEmail));
            mail.Subject = subject;
            mail.Body = message;
            mail.IsBodyHtml = true;

            using (var smtp = new SmtpClient(_emailSettings.PrimaryDomain, _emailSettings.PrimaryPort))
            {
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(_emailSettings.UsernameEmail, _emailSettings.UsernamePassword);
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
        }
        public string GetTemplateFilePathAsync(string templateName)
        {
            var webRootPath = _hostingEnvironment.WebRootPath;
            var pathToFile = webRootPath
                            + Path.DirectorySeparatorChar.ToString()
                            + "template"
                            + Path.DirectorySeparatorChar.ToString()
                            + "email"
                            + Path.DirectorySeparatorChar.ToString()
                            + templateName;

            return pathToFile;
        }
    }
}
