using System;
using System.Collections.Generic;
using System.Text;
using CinemaTickets.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicket.Infrastructure
{
    public class CinemaTicketDbContext : DbContext
    {
        public CinemaTicketDbContext(DbContextOptions<CinemaTicketDbContext> options)
            : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Seance> Seances { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Room> Rooms { get; set; }


    }
}
