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
        private readonly IHostingEnvironment _hostingEnvironment;
        public EmailSender(IOptions<EmailSettings> emailSettings, IHostingEnvironment hostingEnvironment)
        {
            _emailSettings = emailSettings.Value;
            _hostingEnvironment = hostingEnvironment;
        }

        public EmailSettings _emailSettings { get; }

        public Task SendEmailAsync(string email, string subject, string message)
        {

            Execute(email, subject, message).Wait();
            return Task.FromResult(0);
        }

        public async Task Execute(string email, string subject, string message)
        {
                string toEmail = string.IsNullOrEmpty(email)
                                 ? _emailSettings.ToEmail
                                 : email;

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(_emailSettings.FromEmail, "TelMax")
                };
                mail.To.Add(new MailAddress(toEmail));

                using (SmtpClient smtp = new SmtpClient(_emailSettings.PrimaryDomain, _emailSettings.PrimaryPort))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(_emailSettings.UsernameEmail, _emailSettings.UsernamePassword);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }
        }

        public string GetTemplateFilePathAsync(string templateName)
        {
            var webRootPath = _hostingEnvironment.WebRootPath;
            var pathToFile = webRootPath
                            + Path.DirectorySeparatorChar.ToString()
                            + "Template"
                            + Path.DirectorySeparatorChar.ToString()
                            + "EmailTemplate"
                            + Path.DirectorySeparatorChar.ToString()
                            + templateName;

            return pathToFile;
        }
    }
}
