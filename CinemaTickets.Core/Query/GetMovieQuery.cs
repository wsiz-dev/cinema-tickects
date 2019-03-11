using System;
using System.Collections.Generic;
using System.Text;
using CinemaTickets.Core.Query.DTO;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Query;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Core.Query
{
    public class GetMovieQuery : IQuery<MovieDetailsDTO>
    {
        public GetMovieQuery(Guid movieId)
        {
            MovieId = new Id<Movie>(movieId);
        }

        public Id<Movie> MovieId { get; }
    }
}
