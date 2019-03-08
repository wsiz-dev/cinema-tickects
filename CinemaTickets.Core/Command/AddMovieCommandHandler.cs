using System;
using System.Collections.Generic;
using System.Text;
using CinemaTickets.Domain.Command;
using CinemaTickets.Domain.Entities;
using CinemaTickets.Domain.Repositories;
using CSharpFunctionalExtensions;

namespace CinemaTickets.Core.Command
{
    public class AddMovieCommandHandler
        : ICommandHandler<AddMovieCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddMovieCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Result Handle(AddMovieCommand command)
        {
            var isExist = _unitOfWork.MoviesRepository.IsMovieExist(command.Name, command.Year);

            if (isExist == true)
                return  Result.Fail("This Movie already exist");

            var movie = new Movie(command.Name, command.Year, command.SeanceTime);

            return Result.Ok();
        }
    }
}
