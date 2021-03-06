﻿using System.Linq;
using CinemaTickets.Domain.Query;
using CinemaTickets.Domain.Repositories;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace CinemaTickets.Tests.Unit
{
    public class GetSeanceQueryTest
    {
        [Fact]
        public void GetSeance_WhenItsExist_ShouldSuccess()
        {
            using (var sut = new SystemUnderTest())
            {
                var movie = sut.CreateMovie("Harry Potter", 2001, 150);
                var unitOfWorkSubstitute = Substitute.For<IUnitOfWork>();

                unitOfWorkSubstitute.MoviesRepository.GetSeanceDetails(movie.Id)
                    .Returns(movie);

                var query = new GetSeanceQuery(movie.Id.Value, movie.Seances.First().Id.Value);
                var queryHandler = new GetSeanceQueryHanlder(unitOfWorkSubstitute);
                var seanceQuery = queryHandler.Handle(query);

                seanceQuery.MovieName.Should().Be("Harry Potter");
            }
        }
    }
}