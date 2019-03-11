using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Core.Query.DTO
{
    public class MovieSeanceDetailsDTO
    {
        public MovieSeanceDetailsDTO(string name, Id<Movie> movieId, SeanceDetailsDTO seance)
        {
            Name = name;
            MovieId = movieId;
            Seance = seance;
        }

        public string Name { get; }

        public Id<Movie> MovieId { get; }

        public SeanceDetailsDTO Seance { get; }
    }
}