using System;
using CinemaTickets.Domain.Command;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Query;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Core.Query
{
    public sealed class GetSeatsInUseQuery : IQuery<int>
    {
        public GetSeatsInUseQuery(Id<Movie> movieId, DateTime seanceDate, Id<Room> roomId) 
        {
            MovieId = movieId;
            SeanceDate = seanceDate;
            RoomId = roomId;
        }

        public Id<Movie> MovieId { get; }

        public DateTime SeanceDate { get; }

        public Id<Room> RoomId { get; }
    }
}