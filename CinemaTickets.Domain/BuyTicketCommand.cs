using System;

namespace CinemaTickets.Domain
{
    public class BuyTicketCommand
    {
        public BuyTicketCommand(Id<Movie> movieId, DateTime seanceDate, string email, int quantity, int roomNumber)
        {
            SeanceDate = seanceDate;
            Email = email;
            Quantity = quantity;
            MovieId = movieId;
            RoomNumber = roomNumber;
        }

        public Id<Movie> MovieId { get; }

        public DateTime SeanceDate { get; }

        public string Email { get; }

        public int Quantity { get; }
        public int RoomNumber { get; }
    }
}
