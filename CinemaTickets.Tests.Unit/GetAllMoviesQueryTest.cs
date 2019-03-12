using System.Collections.Generic;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Query;
using CinemaTickets.Domain.Repositories;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace CinemaTickets.Tests.Unit
{
    public class GetAllMoviesQueryTest
    {
        [Fact]
        public void GetMovies_WhenItsExist_ReturnCorrectData()
        {
            using (var sut = new SystemUnderTest())
            {
                var movie = sut.CreateMovie("Harry Potter", 2001, 150);
                var movies = new List<Movie> {movie};
                var unitOfWorkSubstitute = Substitute.For<IUnitOfWork>();

                unitOfWorkSubstitute.MoviesRepository.GetAll().Returns(movies);

                var query = new GetAllMoviesQuery();
                var queryHandler = new GetAllMoviesQueryHandler(unitOfWorkSubstitute);
                var moviesQuery = queryHandler.Handle(query);

                moviesQuery[0].Name.Should().Be("Harry Potter");
            }
        }

        [Fact]
        public void GetMovies_WhenItsExist_ShouldSuccess()
        {
            using (var sut = new SystemUnderTest())
            {
                var movie = sut.CreateMovie("Harry Potter", 2001, 150);
                var movies = new List<Movie> {movie};
                var unitOfWorkSubstitute = Substitute.For<IUnitOfWork>();

                unitOfWorkSubstitute.MoviesRepository.GetAll().Returns(movies);

                var query = new GetAllMoviesQuery();
                var queryHandler = new GetAllMoviesQueryHandler(unitOfWorkSubstitute);
                var moviesQuery = queryHandler.Handle(query);

                moviesQuery.Count.Should().Be(1);
            }
        }
    }
}