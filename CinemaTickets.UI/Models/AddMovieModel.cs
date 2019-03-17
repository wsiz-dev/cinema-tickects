using FluentValidation;
using FluentValidation.Results;

namespace CinemaTickets.UI.Models
{
    public sealed class AddMovieModel
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public int SeanceTime { get; set; }

        public ValidationResult Validate()
            => new AddMovieCommandValidator().Validate(this);
    }

    public class AddMovieCommandValidator : AbstractValidator<AddMovieModel>
    {
        public AddMovieCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Year).InclusiveBetween(1900, 2040);
            RuleFor(x => x.SeanceTime).InclusiveBetween(30, 300);
        }
    }
}
