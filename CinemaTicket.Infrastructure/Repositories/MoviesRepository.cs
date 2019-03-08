using System;
using System.Collections.Generic;
using System.Linq;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Repositories;
using CinemaTickets.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicket.Infrastructure.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly CinemaTicketDbContext _context;

        public MoviesRepository(CinemaTicketDbContext context)
        {
            _context = context;
        }

        public Movie GetById(Id<Movie> id)
            => _context.Movies.SingleOrDefault(x => x.Id == id);

        public IEnumerable<Movie> GetAll()
            => _context.Movies.ToList();

        public bool IsMovieExist(string name, int year)
            => _context.Movies.Any(
                x => x.Name == name && x.Year == year);

        public bool IsSeanceExist(DateTime seanceDate, Id<Room> roomId)
            => _context.Seances.Any(
                x => x.Date == seanceDate && x.RoomId == roomId);

        public List<Seance> GetSeancesByMovieId(Id<Movie> movieId)
            => _context.Seances.Where(x => x.MovieId == movieId)
                .ToList();

        public int GetMovieTimeById(Id<Movie> movieId)
            => _context.Movies.Where(x => x.Id == movieId)
                .Select(x => x.SeanceTime)
                .FirstOrDefault();


        public void Add(Movie movie)
        {
            _context.Movies.Add(movie);
        }
    }
}
