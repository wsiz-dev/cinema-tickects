using System;
using System.Collections.Generic;
using System.Linq;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Repositories;
using CinemaTickets.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace CinemaTickets.Infrastructure.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly CinemaTicketDbContext _context;

        public MoviesRepository(CinemaTicketDbContext context)
        {
            _context = context;
        }

        public Movie GetById(Id<Movie> id)
        {
            return _context.Movies
                .Include(c => c.Seances)
                .SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }

        public bool IsMovieExist(string name, int year)
        {
            return _context.Movies.Any(
                x => x.Name == name && x.Year == year);
        }

        public bool IsSeanceExist(DateTime seanceDate)
        {
            return _context.Seances.Any(x => x.Date == seanceDate);
        }

        public List<Seance> GetSeancesByMovieId(Id<Movie> movieId)
        {
            return _context.Seances.Where(x => x.MovieId == movieId)
                .ToList();
        }

        public void Remove(Movie movie)
        {
            _context.Remove(movie);
        }

        public int GetMovieTimeById(Id<Movie> movieId)
        {
            return _context.Movies.Where(x => x.Id == movieId)
                .Select(x => x.SeanceTime)
                .FirstOrDefault();
        }

        public void Update(Movie movie)
        {
            _context.Movies.Update(movie);
        }

        public Movie GetSeanceDetails(Id<Movie> movieId)
        {
            return _context.Movies.Where(x => x.Id == movieId)
                .Include(t => t.Seances)
                .ThenInclude(se => se.Tickets)
                .FirstOrDefault();
        }

        public void Add(Movie movie)
        {
            _context.Movies.Add(movie);
        }
    }
}