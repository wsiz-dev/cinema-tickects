using System;
using CinemaTickets.Domain.Command;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Core.Command
{
    public sealed class RegisterSeanceCommand : ICommand
    {
        public RegisterSeanceCommand(Id<Movie> movieId, DateTime seanceDate, Id<Room> roomId, int quantity)
        {
            MovieId = movieId;
            SeanceDate = seanceDate;
            RoomId = roomId;
            Quantity = quantity;
        }

        public Id<Movie> MovieId { get; }

        public DateTime SeanceDate { get; }

        public Id<Room> RoomId { get; }

        public int Quantity { get; }
    }
}