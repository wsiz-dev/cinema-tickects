using System;
using CinemaTickets.Domain.Command.Seances;
using CinemaTickets.Domain.Repositories;
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
                unitOfWorkSubstitute.MoviesRepository.IsSeanceExist(seanceDate)
                    .Returns(true);

                var command = new RegisterSeanceCommand
                {
                    MovieId = movie.Id.Value,
                    SeanceDate = seanceDate,
                };
                var handler = new RegisterSeanceCommandHandler(unitOfWorkSubstitute);
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

                var command = new RegisterSeanceCommand
                {
                    MovieId = movie.Id.Value,
                    SeanceDate = seanceDate,
                };
                var handler = new RegisterSeanceCommandHandler(unitOfWorkSubstitute);

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

                var command = new RegisterSeanceCommand
                {
                    MovieId = movie.Id.Value,
                    SeanceDate = seanceDate,
                };
                var handler = new RegisterSeanceCommandHandler(unitOfWorkSubstitute);

                handler.Handle(command);
                var result = handler.Handle(command);

                result.IsFailure.Should().BeTrue();
            }
        }
    }
}