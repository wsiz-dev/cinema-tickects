using System;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Domain.Command.Tickets
{
    public sealed class BuyTicketCommand : ICommand
    {
        public BuyTicketCommand(Id<Movie> movieId, DateTime seanceDate, string email, int quantity)
        {
            SeanceDate = seanceDate;
            Email = email;
            Quantity = quantity;
            MovieId = movieId;
        }

        public Id<Movie> MovieId { get; }

        public DateTime SeanceDate { get; }

        public string Email { get; }

        public int Quantity { get; }
    }
}