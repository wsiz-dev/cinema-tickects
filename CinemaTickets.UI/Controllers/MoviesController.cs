using System;
using CinemaTickets.Domain;
using CinemaTickets.Domain.Command.Movies;
using CinemaTickets.Domain.Query.Movies;
using CinemaTickets.UI.Models;
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

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddMovieModel model)
        {
            var validationResult = model.Validate();
            if (validationResult.IsValid == false)
            {
                ModelState.PopulateValidation(validationResult);
                return View(model);
            }

            var result = _mediator.Command(new AddMovieCommand(model.Name, model.Year, model.SeanceTime));
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }

            ViewData["Error"] = result.Message;
            return View(model);
        }

        public IActionResult Edit(Guid id)
        {
            var movie = _mediator.Query(new GetMovieQuery(id));
            var model = new EditMovieModel
            {
                Id = movie.Id,
                Name = movie.Name,
                Year = movie.Year,
                SeanceTime = movie.SeanceTime
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditMovieModel model)
        {
            var validationResult = model.Validate();
            if (validationResult.IsValid == false)
            {
                ModelState.PopulateValidation(validationResult);
                return View(model);
            }

            var result = _mediator.Command(new EditMovieCommand(model.Id, model.Name, model.Year, model.SeanceTime));
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }

            ViewData["Error"] = result.Message;
            return View(model);
        }
    }
}