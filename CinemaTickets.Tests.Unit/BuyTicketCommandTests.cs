using System;
using CinemaTickets.Domain.Command;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Query;
using CinemaTickets.Domain.Repositories;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace CinemaTickets.Tests.Unit
{
    public class BuyTicketCommandTests
    {
        [Fact]
        public void BuyTicket_CountingSeatsInUse_ShouldSuccess()
        {
            var seanceDate = new DateTime(2019, 2, 28, 13, 0, 0);
            const string email = "janusz@wsiz-dev.pl";
            const int quantity = 3;

            using (var sut = new SystemUnderTest())
            {
                var movie = sut.CreateMovie("Harry Potter", 2001, 150);
                var unitOfWorkSubstitute = Substitute.For<IUnitOfWork>();

                unitOfWorkSubstitute.MoviesRepository.GetById(movie.Id)
                    .Returns(movie);
                unitOfWorkSubstitute.RoomRepository.GetById(sut.Rooms[0].Id)
                    .Returns(sut.Rooms[0]);

                movie = unitOfWorkSubstitute.MoviesRepository.GetById(movie.Id);
                var seance = movie.GetSeanceByDateAdnRoomId(seanceDate, sut.Rooms[0].Id);

                seance.Add(new Ticket("dawid@wsiz-dev.pl", 17));

                var command = new BuyTicketCommand(movie.Id, seanceDate, email, quantity, sut.Rooms[0].Id);
                var handler = new BuyTicketCommandHandler(unitOfWorkSubstitute);

                handler.Handle(command);

                var query = new GetSeatsInUseQuery(movie.Id, seanceDate, sut.Rooms[0].Id);
                var queryHandler = new GetSeatsInUseQueryHandler(unitOfWorkSubstitute);

                var seatsInUse = queryHandler.Handle(query);

                seatsInUse.Should().Be(20);
            }
        }

        [Fact]
        public void BuyTicket_WhenItIsPossible_ShouldSuccess()
        {
            var seanceDate = new DateTime(2019, 3, 1, 17, 0, 0);
            const string email = "janusz@wsiz-dev.pl";
            const int quantity = 2;

            using (var sut = new SystemUnderTest())
            {
                var movie = sut.CreateMovie("Harry Potter", 2001, 150);
                var unitOfWorkSubstitute = Substitute.For<IUnitOfWork>();

                unitOfWorkSubstitute.MoviesRepository.GetById(movie.Id)
                    .Returns(movie);
                unitOfWorkSubstitute.RoomRepository.GetById(sut.Rooms[2].Id)
                    .Returns(sut.Rooms[2]);

                var command = new BuyTicketCommand(movie.Id, seanceDate, email, quantity, sut.Rooms[2].Id);
                var handler = new BuyTicketCommandHandler(unitOfWorkSubstitute);
                handler.Handle(command);

                movie = unitOfWorkSubstitute.MoviesRepository.GetById(movie.Id);
                var seance = movie.GetSeanceByDateAdnRoomId(seanceDate, sut.Rooms[2].Id);
                var ticket = seance.GetTicketByEmail(email);

                ticket[0].PeopleCount.Should().Be(2);
            }
        }

        [Fact]
        public void BuyTicket_WhenThereAreNoSeats_ShouldFail()
        {
            var seanceDate = new DateTime(2019, 3, 1, 14, 0, 0);
            const string email = "janusz@wsiz-dev.pl";
            const int quantity = 222;

            using (var sut = new SystemUnderTest())
            {
                var movie = sut.CreateMovie("Harry Potter", 2001, 150);
                var unitOfWorkSubstitute = Substitute.For<IUnitOfWork>();

                unitOfWorkSubstitute.MoviesRepository.GetById(movie.Id)
                    .Returns(movie);
                unitOfWorkSubstitute.RoomRepository.GetById(sut.Rooms[1].Id)
                    .Returns(sut.Rooms[1]);

                var command = new BuyTicketCommand(movie.Id, seanceDate, email, quantity, sut.Rooms[1].Id);
                var handler = new BuyTicketCommandHandler(unitOfWorkSubstitute);
                var result = handler.Handle(command);

                result.IsFailure.Should().BeTrue();
            }
        }
    }
}