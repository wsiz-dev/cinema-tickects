﻿using System;
using System.Collections.Generic;

namespace CinemaTickets.Domain.Query.DTO
{
    public class MovieDetailsDTO
    {
        public MovieDetailsDTO(Guid id, string name, int year, int seanceTime, List<SeanceDTO> seances)
        {
            Id = id;
            Name = name;
            Seances = seances;
            Year = year;
            SeanceTime = seanceTime;
        }

        public Guid Id { get; }

        public string Name { get; }

        public int Year { get; }

        public int SeanceTime { get; }

        public List<SeanceDTO> Seances { get; }
    }
}