using System;
using CinemaTickets.Domain.Command;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Core.Command
{
    public sealed class BuyTicketCommand : ICommand
    {
        public BuyTicketCommand(Id<Movie> movieId, DateTime seanceDate, string email, int quantity, Id<Room> roomId)
        {
            SeanceDate = seanceDate;
            Email = email;
            Quantity = quantity;
            RoomId = roomId;
            MovieId = movieId;
        }

        public Id<Movie> MovieId { get; }

        public DateTime SeanceDate { get; }

        public string Email { get; }

        public int Quantity { get; }

        public Id<Room> RoomId { get; }
    }
}