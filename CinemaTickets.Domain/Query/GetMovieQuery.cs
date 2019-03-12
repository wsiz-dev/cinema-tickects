using System;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Query.DTO;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Domain.Query
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
