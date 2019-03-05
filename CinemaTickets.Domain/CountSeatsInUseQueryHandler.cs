using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaTickets.Domain
{
    public class CountSeatsInUseQueryHandler
    {
        public CountSeatsInUseQueryHandler()
        {

        }

        public int Handle(CountSeatsInUseQuery query)
        {

            var purchesedTickets = query.Seance.GetAllSeanceTicket();
            int seatsInUsing = 0;

            foreach (var item in purchesedTickets)
            {
                seatsInUsing += item.PeopleCount;
            }

            return seatsInUsing;
        }
    }
}
