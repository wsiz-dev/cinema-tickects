using System;
using System.Collections.Generic;
using System.Text;
using CinemaTickets.Domain.Command;

namespace CinemaTickets.Core.Command
{
    public class AddMovieCommand : ICommand
    {
        public AddMovieCommand(string name, int year, int seanceTime)
        {
            Name = name;
            Year = year;
            SeanceTime = seanceTime;
        }

        public string Name { get; }
        public int Year { get; }
        public int SeanceTime { get; }
    }
}
