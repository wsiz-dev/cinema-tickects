using System.Linq;
using CinemaTickets.Domain.Command;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Repositories;
using CSharpFunctionalExtensions;

namespace CinemaTickets.Core.Command
{
    public sealed class BuyTicketCommandHandler
        : ICommandHandler<BuyTicketCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BuyTicketCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

            return Result.Ok();
        }
    }
}