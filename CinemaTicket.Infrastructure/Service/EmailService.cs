using System.IO;
using CinemaTickets.Domain.Service;
using CinemaTickets.Domain.Service.DTO;
using MimeKit;

namespace CinemaTickets.Infrastructure.Service
{
    public class EmailService : IEmailService
    {
        private readonly IEmailSender _emailSender;

        public EmailService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public void SendPurchaseNotification(PurchaseNotificationDto purchaseNotification)
        {
            var builder = new BodyBuilder();
            var pathToFile = _emailSender.GetTemplateFilePathAsync("PurchaseNotification.html");
            var subject = "Twój wirtualny bilet do Cinema Tickets";

            using (var sourceReader = File.OpenText(pathToFile))
            {
                builder.HtmlBody = sourceReader.ReadToEnd();
            }

            var messageBody = string.Format(builder.HtmlBody,
                purchaseNotification.Email,
                purchaseNotification.MovieName,
                purchaseNotification.PeopleCount,
                purchaseNotification.SeanceDate,
                purchaseNotification.Id.Value
            );

            _emailSender.SendEmailAsync(purchaseNotification.Email, subject, messageBody);
        }
    }
}
