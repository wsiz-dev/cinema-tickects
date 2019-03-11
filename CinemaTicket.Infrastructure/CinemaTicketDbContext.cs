using System;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace CinemaTickets.Infrastructure
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Entities relations

            modelBuilder.Entity<Movie>(m =>
            {
                m.HasKey(x => x.Id);
                m.Property(e => e.Id)
                    .HasConversion(
                        v => v.Value,
                        v => new Id<Movie>(v));
            });

            modelBuilder.Entity<Room>(m =>
            {
                m.HasKey(x => x.Id);
                m.Property(e => e.Id)
                    .HasConversion(
                        v => v.Value,
                        v => new Id<Room>(v));
            });

            modelBuilder.Entity<Seance>(m =>
            {
                m.HasKey(x => x.Id);
                m.Property(e => e.Id)
                    .HasConversion(
                        v => v.Value,
                        v => new Id<Seance>(v));
                m.Property(e => e.MovieId)
                    .HasConversion(
                        v => v.Value,
                        v => new Id<Movie>(v));
                m.Property(e => e.RoomId)
                    .HasConversion(
                        v => v.Value,
                        v => new Id<Room>(v));
            });

            modelBuilder.Entity<Ticket>(m =>
            {
                m.HasKey(x => x.Id);
                m.Property(e => e.Id)
                    .HasConversion(
                        v => v.Value,
                        v => new Id<Ticket>(v));
            });

            #endregion

            #region Seed data

            var firstRoom = new Room(1, 50);
            var secondRoom = new Room(2, 50);
            var thirdRoom = new Room(3, 50);

            modelBuilder.Entity<Room>().HasData(firstRoom, secondRoom, thirdRoom);

            var firstMovie = new Movie("Harry Potter i Czara Ognia", 2010, 150);
            var secondMovie = new Movie("Szybcy i wściekli 8", 2018, 180);
            var thirdMovie = new Movie("Alita", 2019, 120);

            modelBuilder.Entity<Movie>().HasData(firstMovie, secondMovie, thirdMovie);

            var firstDate = new DateTime(2019, 3, 10, 18, 30, 0);
            var secondDate = new DateTime(2019, 3, 10, 22, 30, 0);
            var thirdDate = new DateTime(2019, 4, 10, 18, 30, 0);

            var firstSeance = new Seance(firstDate, firstRoom.Id, firstMovie.Id);
            var secondSeance = new Seance(secondDate, secondRoom.Id, secondMovie.Id);
            var thirdSeance = new Seance(thirdDate, thirdRoom.Id, thirdMovie.Id);

            modelBuilder.Entity<Seance>().HasData(firstSeance, secondSeance, thirdSeance);

            #endregion
        }
    }
}