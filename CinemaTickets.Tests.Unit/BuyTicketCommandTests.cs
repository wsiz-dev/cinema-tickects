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
                var seanceDate = new DateTime(2019, 3, 1, 17, 0, 0);
                var roomNumber = 3;
                const string email = "janusz@wsiz-dev.pl";
                const int quantity = 2;

                var command = new BuyTicketCommand(movie.Id, seanceDate, email, quantity, roomNumber);
                var handler = new BuyTicketCommandHandler(sut.MoviesRepository);

                handler.Handle(command);

                movie = sut.MoviesRepository.GetById(movie.Id);
                var seance = movie.GetSeanceByDateAdnRoomNumber(seanceDate, roomNumber);
                var ticket = seance.GetTicketByEmail(email);

                ticket[0].PeopleCount.Should().Be(2);
            }
        }

        [Fact]
        public void BuyTicket_WhenThereAreNoSeats_ShouldThrowException()
        {
            using (var sut = new SystemUnderTest())
            {
                var movie = sut.CreateMovie("Harry Potter", 2001);
                sut.MoviesRepository.Add(movie);

                var seanceDate = new DateTime(2019, 3, 1, 14, 0, 0);
                var roomNumber = 2;
                const string email = "janusz@wsiz-dev.pl";
                const int quantity = 3;

                var command = new BuyTicketCommand(movie.Id, seanceDate, email, quantity, roomNumber);
                var handler = new BuyTicketCommandHandler(sut.MoviesRepository);

                Action action = () => handler.Handle(command);

                action.Should().Throw<ArgumentOutOfRangeException>();
            }
        }

        [Fact]
        public void BuyTicket_CountSeatsInUsingForEveryPurches_ShouldSuccess()
        {
            using (var sut = new SystemUnderTest())
            {
                var movie = sut.CreateMovie("Harry Potter", 2001);
                sut.MoviesRepository.Add(movie);

                var seanceDate = new DateTime(2019, 2, 28, 13, 0, 0);
                var roomNumber = 1;
                const string email = "janusz@wsiz-dev.pl";
                const int quantity = 3;
                movie = sut.MoviesRepository.GetById(movie.Id);
                var seance = movie.GetSeanceByDateAdnRoomNumber(seanceDate, roomNumber);

                seance.Add(new Ticket("dawid@wsiz-dev.pl", 17));

                var command = new BuyTicketCommand(movie.Id, seanceDate, email, quantity, roomNumber);
                var handler = new BuyTicketCommandHandler(sut.MoviesRepository);

                handler.Handle(command);

                var query = new CountSeatsInUseQuery(seance);
                var queryHandler = new CountSeatsInUseQueryHandler();

                var seatsInUse = queryHandler.Handle(query);

                seatsInUse.Should().Be(20);
            }
        }
    }
}
