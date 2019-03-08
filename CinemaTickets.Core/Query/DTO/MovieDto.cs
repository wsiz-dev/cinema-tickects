using System;
using System.Collections.Generic;
using System.Text;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Core.Query.DTO
{
    public class MovieDto
    {
        public MovieDto(string name, Id<Movie> id)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; }

        public Id<Movie> Id { get; }
    }
}
