﻿using System;
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

        bool IsSeanceExist(DateTime seanceDate, Id<Room> roomId);

        int GetMovieTimeById(Id<Movie> movieId);

        void Add(Movie movie);

        Movie GetSeanceDetails(Id<Movie> movieId);

        List<Seance> GetSeancesByMovieId(Id<Movie> movieId);
    }
}