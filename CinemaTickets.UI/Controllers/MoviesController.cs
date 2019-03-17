using CinemaTickets.Domain;
using CinemaTickets.Domain.Query;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTickets.UI.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            var movies = _mediator.Query(new GetAllMoviesQuery());

            return View(movies);
        }
    }
}