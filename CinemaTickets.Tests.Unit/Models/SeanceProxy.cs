using System;
using System.Collections.Generic;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Tests.Unit.Models
{
    public class SeanceProxy : Seance
    {
        public SeanceProxy(DateTime date, Id<Movie> movieId) : base(date, movieId)
        {
            Tickets = new List<Ticket>();
        }
    }
}
