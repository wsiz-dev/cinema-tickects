using System;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Domain.Query
{
    public sealed class GetSeatsInUseQuery : IQuery<int>
    {
        public GetSeatsInUseQuery(Id<Movie> movieId, DateTime seanceDate) 
        {
            MovieId = movieId;
            SeanceDate = seanceDate;
        }

        public Id<Movie> MovieId { get; }

        public DateTime SeanceDate { get; }
    }
}