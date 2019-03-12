using CinemaTickets.Domain;
using CinemaTickets.Domain.Query;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTickets.UI.Controllers
{
    public class MovieController : Controller
    {
        private readonly Messages _messages;

        public MovieController(Messages messages)
        {
            _messages = messages;
        }

        public IActionResult Index()
        {
            var movies = _messages.Dispatch(new GetAllMoviesQuery());

            return View(movies);
        }
    }
}