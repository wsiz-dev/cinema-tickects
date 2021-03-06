﻿using System;
using CinemaTickets.Domain;
using CinemaTickets.Domain.Command.Movies;
using CinemaTickets.Domain.Query.Movies;
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
        public IActionResult Add(AddMovieCommand command)
        {
            var result = _mediator.Command(command);
            if (result.IsFailure)
            {
                ModelState.PopulateValidation(result.Errors);
                return View(command);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            var movie = _mediator.Query(new GetMovieQuery(id));
            var model = new EditMovieCommand
            {
                Id = movie.Id,
                Name = movie.Name,
                Year = movie.Year,
                SeanceTime = movie.SeanceTime
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditMovieCommand command)
        {
            var result = _mediator.Command(command);
            if (result.IsFailure)
            {
                ModelState.PopulateValidation(result.Errors);
                return View(command);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var result = _mediator.Command(new DeleteMovieCommand(id));
            if (result.IsSuccess == false)
            {
                ViewData["Error"] = result.Message;
            }

            return RedirectToAction("Index");
        }
    }
}