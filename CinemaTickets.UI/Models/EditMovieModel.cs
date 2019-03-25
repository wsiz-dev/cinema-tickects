using System;
using FluentValidation;
using FluentValidation.Results;

namespace CinemaTickets.UI.Models
{
    public sealed class EditMovieModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int SeanceTime { get; set; }

        public ValidationResult Validate()
            => new EditMovieModelValidator().Validate(this);
    }

    public class EditMovieModelValidator : AbstractValidator<EditMovieModel>
    {
        public EditMovieModelValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Year).InclusiveBetween(1900, 2040);
            RuleFor(x => x.SeanceTime).InclusiveBetween(30, 300);
        }
    }
}
