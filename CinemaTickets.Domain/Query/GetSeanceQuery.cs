using System;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Query.DTO;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Domain.Query
{
    public class GetSeanceQuery : IQuery<MovieSeanceDetails>
    {
        public GetSeanceQuery(Guid movieId, Guid seanceId)
        {
            MovieId = new Id<Movie>(movieId);
            SeanceId = new Id<Seance>(seanceId);
        }

        public Id<Movie> MovieId { get; }
        public Id<Seance> SeanceId { get; }
    }
}
