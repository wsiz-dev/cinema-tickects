using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaTickets.Domain
{
    public class GetAllMoviesQuery
    {
        public GetAllMoviesQuery()
        {
        }

    }
    public class MoviesList
    {
        public MoviesList(string name, Id<Movie> id)
        {
            Name = name;
            Id = id;
        }
        public string Name { get; }
        public Id<Movie> Id { get; }
    }
}
