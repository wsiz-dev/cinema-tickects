using System;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Domain.Query.DTO
{
    public class MovieSeanceDetails
    {
        public MovieSeanceDetails(Movie movie, Seance seance)
        {
            MovieName = movie.Name;
            MovieId = movie.Id;
            SeanceId = seance.Id;
            SeanceDate = seance.Date;
        }

        public Id<Movie> MovieId { get; }

        public Id<Seance> SeanceId { get; }

        public string MovieName { get; }

        public DateTime SeanceDate { get; }
    }
}