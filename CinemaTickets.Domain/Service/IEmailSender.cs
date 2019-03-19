using System.Threading.Tasks;

namespace CinemaTickets.Domain.Service
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);

        string GetTemplateFilePathAsync(string templateName);
    }
}
