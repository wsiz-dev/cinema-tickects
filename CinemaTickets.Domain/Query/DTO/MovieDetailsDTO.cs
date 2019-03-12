using System.Collections.Generic;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Domain.Query.DTO
{
    public class MovieDetailsDTO
    {
        public MovieDetailsDTO(string name, Id<Movie> movieId, List<SeanceDTO> seances)
        {
            Name = name;
            MovieId = movieId;
            Seances = seances;
        }

        public string Name { get; }

        public Id<Movie> MovieId { get; }

        public List<SeanceDTO> Seances { get; }
    }
}