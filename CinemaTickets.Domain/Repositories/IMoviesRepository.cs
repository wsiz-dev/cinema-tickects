using System;
using System.Collections.Generic;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Domain.Repositories
{
    public interface IMoviesRepository
    {
        Movie GetById(Id<Movie> id);

        IEnumerable<Movie> GetAll();

        bool IsMovieExist(string name, int year);

        bool IsSeanceExist(DateTime seanceDate);

        void Add(Movie movie);

        void Update(Movie movie);

        Movie GetSeanceDetails(Id<Movie> movieId);

        List<Seance> GetSeancesByMovieId(Id<Movie> movieId);

        void Remove(Movie movie);
    }
}