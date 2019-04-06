using System.Collections.Generic;
using CinemaTickets.Domain.Entities;

namespace CinemaTickets.Tests.Unit.Models
{
    public class MovieProxy : Movie
    {
        public MovieProxy(string name, int year, int seanceTime) : base(name, year, seanceTime)
        {
            Seances = new List<Seance>();
        }
    }
}
