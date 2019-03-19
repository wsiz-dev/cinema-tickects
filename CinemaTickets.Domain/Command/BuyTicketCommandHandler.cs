using System.Linq;
using System.Threading.Tasks;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Repositories;
using CinemaTickets.Domain.Service;
using CinemaTickets.Domain.Service.DTO;

namespace CinemaTickets.Domain.Command
{
    public sealed class BuyTicketCommandHandler
        : ICommandHandler<BuyTicketCommand>
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
            var seance = movie.GetSeanceByDateAdnRoomId(command.SeanceDate, command.RoomId);
            var purchasedTickets = seance.GetAllSeanceTicket();
            var seatsInUse = purchasedTickets.Sum(x => x.PeopleCount);
            var room = _unitOfWork.RoomRepository.GetById(seance.RoomId);
            var freeSeats = room.Seats - seatsInUse;

            if (freeSeats < command.Quantity)
                return Result.Fail("Number of ticket is greater than number of seats");

            seance.Add(ticket);
            _unitOfWork.Commit();

            var purchaseNotification = new PurchaseNotificationDto(command.Email, ticket.Id, command.Quantity,
                seance.Date, movie.Name, room.RoomNumber);

            _emailService.SendPurchaseNotification(purchaseNotification);

            return Result.Ok();
        }
    }
}