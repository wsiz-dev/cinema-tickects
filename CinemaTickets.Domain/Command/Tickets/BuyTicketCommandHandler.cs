using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Repositories;
using CinemaTickets.Domain.Service;
using CinemaTickets.Domain.Service.DTO;

namespace CinemaTickets.Domain.Command.Tickets
{
    internal class BuyTicketCommandHandler : ICommandHandler<BuyTicketCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;
        private readonly IBackgroundJob _backgroundJob;

        public BuyTicketCommandHandler(IUnitOfWork unitOfWork, IEmailService emailService, IBackgroundJob backgroundJob)
        {
            _unitOfWork = unitOfWork;
            _emailService = emailService;
            _backgroundJob = backgroundJob;
        }

        public Result Handle(BuyTicketCommand command)
        {
            var validationResult = new BuyTicketCommandValidator().Validate(command);
            if (validationResult.IsValid == false)
            {
                return Result.Fail(validationResult);
            }

            var ticket = new Ticket(command.Email, command.Quantity);
            var movie = _unitOfWork.MoviesRepository.GetById(command.MovieId);
            var seance = movie.GetSeanceByDateAdnRoomId(command.SeanceDate);

            seance.Add(ticket);
            _unitOfWork.Commit();

            var purchaseNotification = new PurchaseNotificationDto(command.Email, ticket.Id, command.Quantity, seance.Date, movie.Name);

            _backgroundJob.Enqueue(
                () => _emailService.SendPurchaseNotification(purchaseNotification));
            
            return Result.Ok();
        }
    }
}