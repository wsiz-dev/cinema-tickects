using System;
using System.Collections.Generic;
using System.Text;
using CinemaTickets.Core.Query.DTO;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Query;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Core.Query
{
    public class GetSeanceQuery : IQuery<MovieSeanceDetailsDTO>
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
