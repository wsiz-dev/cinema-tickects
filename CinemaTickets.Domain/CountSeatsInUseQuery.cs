using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaTickets.Domain
{
    public class CountSeatsInUseQuery
    {
        public CountSeatsInUseQuery(Seance seance)
        {
            Seance = seance;
        }
        public Seance Seance { get; }

    }
}
