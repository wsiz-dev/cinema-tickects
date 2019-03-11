using System;
using CinemaTickets.Core.Query;
using CinemaTickets.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTickets.UI.Controllers
{
    [Route("[controller]/[action]")]
    public class SeanceController : Controller
    {
        private readonly Messages _messages;

        public SeanceController(Messages messages)
        {
            _messages = messages;
        }

        [HttpGet("{id}")]
        public IActionResult Index(Guid id)
        {
            var movie = _messages.Dispatch(new GetMovieQuery(id));
            return View(movie);
        }

        [HttpGet("{movieId?}/{seanceId?}")]
        public IActionResult BuyTicket(Guid movieId, Guid seanceId)
        {
            var seanceDetails = _messages.Dispatch(new GetSeanceQuery(movieId, seanceId));
            return View();
        }
    }
}