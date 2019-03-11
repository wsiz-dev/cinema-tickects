using CinemaTickets.Core.Query;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Repositories;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace CinemaTickets.Tests.Unit
{
    public class GetMovieQueryTest
    {
        [Fact]
        public void GetMovie_WhenItsExist_ShouldSuccess()
        {
            using (var sut = new SystemUnderTest())
            {
                var movie = sut.CreateMovie("Harry Potter", 2001, 150);
                var unitOfWorkSubstitute = Substitute.For<IUnitOfWork>();

                unitOfWorkSubstitute.MoviesRepository.GetById(movie.Id).Returns(movie);

                var query = new GetMovieQuery(movie.Id.Value);
                var queryHandler = new GetMovieQueryHandler(unitOfWorkSubstitute);
                var moviesQuery = queryHandler.Handle(query);

                moviesQuery.Name.Should().Be("Harry Potter");
            }
        }

        [Fact]
        public void GetMovie_WhenNoSeance_ShouldSuccess()
        {
            using (var sut = new SystemUnderTest())
            {
                var movie = new Movie("Harry Potter", 2001, 150);
                var unitOfWorkSubstitute = Substitute.For<IUnitOfWork>();

                unitOfWorkSubstitute.MoviesRepository.GetById(movie.Id)
                    .Returns(movie);

                var query = new GetMovieQuery(movie.Id.Value);
                var queryHandler = new GetMovieQueryHandler(unitOfWorkSubstitute);
                var moviesQuery = queryHandler.Handle(query);

                moviesQuery.Seances.Count.Should().Be(0);
            }
        }
    }
}