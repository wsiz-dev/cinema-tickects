using System;
using System.Collections.Generic;
using System.Text;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.ValueObjects;

namespace CinemaTickets.Domain.Service.DTO
{
    public class PurchaseNotificationDto
    {
        public PurchaseNotificationDto(string email, Id<Ticket> id, int peopleCount, DateTime seanceDate, string movieName, int roomNumber)
        {
            Email = email;
            Id = id;
            PeopleCount = peopleCount;
            SeanceDate = seanceDate;
            MovieName = movieName;
            RoomNumber = roomNumber;
        }

        public string Email { get; }

        public Id<Ticket> Id { get; }

        public int PeopleCount { get; }

        public DateTime SeanceDate { get; }

        public string MovieName { get; }

        public int RoomNumber { get; }

    }
}
