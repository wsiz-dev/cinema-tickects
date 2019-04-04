using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Repositories;
using CinemaTickets.Domain.Service;
using CinemaTickets.Domain.Service.DTO;
using Hangfire;

namespace CinemaTickets.Domain.Command
{
    internal class BuyTicketCommandHandler : ICommandHandler<BuyTicketCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IEmailService _emailService;

        public BuyTicketCommandHandler(IUnitOfWork unitOfWork, IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _emailService = emailService;
        }

        public Result Handle(BuyTicketCommand command)
        {
            var ticket = new Ticket(command.Email, command.Quantity);
            var movie = _unitOfWork.MoviesRepository.GetById(command.MovieId);
            var seance = movie.GetSeanceByDateAdnRoomId(command.SeanceDate);

            seance.Add(ticket);
            _unitOfWork.Commit();

            var purchaseNotification = new PurchaseNotificationDto(command.Email, ticket.Id, command.Quantity, seance.Date, movie.Name);

            BackgroundJob.Enqueue(
                () => _emailService.SendPurchaseNotification(purchaseNotification));
            
            return Result.Ok();
        }
    }
}