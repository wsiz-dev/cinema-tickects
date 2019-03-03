using System;
using CinemaTickets.Domain;
using FluentAssertions;
using Xunit;

namespace CinemaTickets.Tests.Unit
{
    public class BuyTicketCommandTests
    {
        [Fact]
        public void BuyTicket_WhenItIsPossible_ShouldSuccess()
        {
            using (var sut = new SystemUnderTest())
            {
                var movie = sut.CreateMovie("Harry Potter", 2001);
                sut.MoviesRepository.Add(movie);
                var screeningDate = new DateTime(2019, 3, 1, 13, 0, 0);
                const string email = "janusz@wsiz-dev.pl";

                var command = new BuyTicketCommand(movie.Id, screeningDate, email, 2);
                var handler = new BuyTicketCommandHandler();

                handler.Handle(command);

                movie = sut.MoviesRepository.GetById(movie.Id);
                var screening = movie.GetScreeningByDate(screeningDate);
                var ticket = screening.GetTicketByEmail(email);

                ticket.PeopleCount.Should().Be(2);
            }
        }
    }
}
