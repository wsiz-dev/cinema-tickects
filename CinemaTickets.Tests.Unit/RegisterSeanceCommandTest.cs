using System;
using CinemaTickets.Domain.Command.Seances;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Repositories;
using CinemaTickets.Domain.Service;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace CinemaTickets.Tests.Unit
{
    public class RegisterSeanceCommandTest
    {
        [Fact]
        public void RegisterSeance_WhenExist_ShouldFail()
        {
            using (var sut = new SystemUnderTest())
            {
                var seanceDate = new DateTime(2019, 2, 28, 13, 0, 0);
                var movie = sut.CreateMovie("Harry Potter", 2001, 150);
                var unitOfWorkSubstitute = Substitute.For<IUnitOfWork>();

                unitOfWorkSubstitute.MoviesRepository.GetById(movie.Id)
                    .Returns(movie);
                unitOfWorkSubstitute.MoviesRepository.GetSeancesByMovieId(movie.Id)
                    .Returns(movie.Seances);
                unitOfWorkSubstitute.MoviesRepository.IsSeanceExist(seanceDate, sut.Rooms[1].Id)
                    .Returns(true);
                var roomServiceSubstitute = Substitute.For<IRoomService>();

                roomServiceSubstitute.GetTimeSpanAfterSeanceDate(sut.Rooms[1], seanceDate, movie.SeanceTime)
                    .Returns(movie.SeanceTime);
                roomServiceSubstitute.GetTimeSpanBeforeSeanceDate(sut.Rooms[1], seanceDate, movie.SeanceTime)
                    .Returns(movie.SeanceTime);


                var command = new RegisterSeanceCommand
                {
                    MovieId = movie.Id,
                    SeanceDate = seanceDate,
                    RoomId = sut.Rooms[0].Id
                };
                var handler = new RegisterSeanceCommandHandler(unitOfWorkSubstitute, roomServiceSubstitute);
                var result = handler.Handle(command);

                result.IsSuccess.Should().BeFalse();
            }
        }

        [Fact]
        public void RegisterSeance_WhenItIsPossible_ShouldSuccess()
        {
            using (var sut = new SystemUnderTest())
            {
                var seanceDate = new DateTime(2019, 4, 1, 11, 0, 0);
                var movie = sut.CreateMovie("Harry Potter", 2001, 150);
                var unitOfWorkSubstitute = Substitute.For<IUnitOfWork>();

                unitOfWorkSubstitute.MoviesRepository.GetById(movie.Id)
                    .Returns(movie);
                unitOfWorkSubstitute.MoviesRepository.GetSeancesByMovieId(movie.Id)
                    .Returns(movie.Seances);
                unitOfWorkSubstitute.RoomRepository.GetById(sut.Rooms[0].Id)
                    .Returns(sut.Rooms[0]);

                var roomServiceSubstitute = Substitute.For<IRoomService>();

                roomServiceSubstitute.GetTimeSpanAfterSeanceDate(sut.Rooms[0], seanceDate, movie.SeanceTime)
                    .Returns(movie.SeanceTime);
                roomServiceSubstitute.GetTimeSpanBeforeSeanceDate(sut.Rooms[0], seanceDate, movie.SeanceTime)
                    .Returns(movie.SeanceTime);

                var command = new RegisterSeanceCommand
                {
                    MovieId = movie.Id,
                    SeanceDate = seanceDate,
                    RoomId = sut.Rooms[0].Id
                };
                var handler = new RegisterSeanceCommandHandler(unitOfWorkSubstitute, roomServiceSubstitute);

                handler.Handle(command);

                movie = unitOfWorkSubstitute.MoviesRepository.GetById(movie.Id);
                var seances = unitOfWorkSubstitute.MoviesRepository.GetSeancesByMovieId(movie.Id);

                seances.Count.Should().Be(4);
            }
        }

        [Fact]
        public void RegisterSeance_WhenOtherSeanceAtTheSameTime_ShouldFail()
        {
            using (var sut = new SystemUnderTest())
            {
                var seanceDate = new DateTime(2019, 4, 1, 11, 0, 0);
                var movie = sut.CreateMovie("Harry Potter", 2001, 150);
                var unitOfWorkSubstitute = Substitute.For<IUnitOfWork>();

                unitOfWorkSubstitute.MoviesRepository.GetById(movie.Id)
                    .Returns(movie);
                unitOfWorkSubstitute.MoviesRepository.GetSeancesByMovieId(movie.Id)
                    .Returns(movie.Seances);
                unitOfWorkSubstitute.RoomRepository.GetById(sut.Rooms[0].Id)
                    .Returns(sut.Rooms[0]);

                var roomServiceSubstitute = Substitute.For<IRoomService>();

                roomServiceSubstitute.GetTimeSpanAfterSeanceDate(sut.Rooms[0], seanceDate, movie.SeanceTime)
                    .Returns(0);
                roomServiceSubstitute.GetTimeSpanBeforeSeanceDate(sut.Rooms[0], seanceDate, movie.SeanceTime)
                    .Returns(0);

                var seance = new Seance(new DateTime(2019, 4, 1, 10, 0, 0), sut.Rooms[0].Id, movie.Id);
                sut.Rooms[0].Seances.Add(seance);
                seance = new Seance(new DateTime(2019, 4, 1, 12, 30, 0), sut.Rooms[0].Id, movie.Id);
                sut.Rooms[0].Seances.Add(seance);

                var command = new RegisterSeanceCommand
                {
                    MovieId = movie.Id,
                    SeanceDate = seanceDate,
                    RoomId = sut.Rooms[0].Id
                };
                var handler = new RegisterSeanceCommandHandler(unitOfWorkSubstitute, roomServiceSubstitute);

                handler.Handle(command);
                var result = handler.Handle(command);

                result.IsFailure.Should().BeTrue();
            }
        }
    }
}