using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaTickets.Domain
{
    internal class BuyTicketCommandHandler
    {
        private readonly IMoviesRepository _moviesRepository;


        public BuyTicketCommandHandler(IMoviesRepository moviesRepository) 
        {
            _moviesRepository = moviesRepository;
        }

        public void Handle(BuyTicketCommand command)
        {
            var ticket = new Ticket(command.Email, command.Quantity);
            var movie = _moviesRepository.GetById(command.MovieId);
            var seance = movie.GetSeanceByDateAdnRoomNumber(command.SeanceDate, command.RoomNumber);
            var query = new CountSeatsInUseQuery(seance);
            var handler = new CountSeatsInUseQueryHandler();

            int seatsInUse = handler.Handle(query);
            var freeSeats = seance.Seats - seatsInUse;

            if(freeSeats < command.Quantity)
            {
                throw new ArgumentOutOfRangeException("Number of tickets is greater than number of seats");
            }
            else
            {
                seance.Add(ticket);
            }

        }
    }
}
