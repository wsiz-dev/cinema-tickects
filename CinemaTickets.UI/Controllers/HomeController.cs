using System.Diagnostics;
using CinemaTickets.Domain;
using CinemaTickets.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTickets.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly Messages _messages;

        public HomeController(Messages messages)
        {
            _messages = messages;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}