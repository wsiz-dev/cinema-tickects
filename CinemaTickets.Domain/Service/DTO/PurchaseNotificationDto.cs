using System;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Domain.Service.DTO
{
    public class PurchaseNotificationDto
    {
        public PurchaseNotificationDto(string email, Id<Ticket> id, int peopleCount, DateTime seanceDate, string movieName)
        {
            Email = email;
            Id = id;
            PeopleCount = peopleCount;
            SeanceDate = seanceDate;
            MovieName = movieName;
        }

        public string Email { get; }

        public Id<Ticket> Id { get; }

        public int PeopleCount { get; }

        public DateTime SeanceDate { get; }

        public string MovieName { get; }
    }
}
