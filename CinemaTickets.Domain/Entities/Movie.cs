﻿using System;
using System.Collections.Generic;
using System.Linq;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Domain.Entities
{
    public class Movie
    {
        protected Movie()
        {
        }

        public Movie(string name, int year, int seanceTime)
        {
            Id = new Id<Movie>(Guid.NewGuid());
            Name = name;
            Year = year;
            SeanceTime = seanceTime;
        }

        public Id<Movie> Id { get; protected set; }

        public string Name { get; protected set; }

        public int Year { get; protected set; }

        public int SeanceTime { get; protected set; }

        public virtual ICollection<Seance> Seances { get; protected set; }

        public Seance GetSeanceByDateAdnRoomId(DateTime date)
        {
            return Seances.SingleOrDefault(x => x.Date == date);
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetYear(int year)
        {
            Year = year;
        }

        public void SetSeanceTime(int seanceTime)
        {
            SeanceTime = seanceTime;
        }
    }
}