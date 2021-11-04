using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OMDBapi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OMDBapi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private MovieDAL movieDAL = new MovieDAL();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MovieSearch()
        {
            return View();
        }

        public IActionResult MovieNight()
        {
            return View();
        }

        public IActionResult MovieSearchResult(string Title)
        {
            MovieModel result = movieDAL.GetData(Title);
            return View(result);
        }

        public IActionResult MovieNightResult(string Title, string TitleTwo, string TitleThree)
        {
            MovieModel result = movieDAL.GetData(Title);
            MovieModel result2 = movieDAL.GetData(TitleTwo);
            MovieModel result3 = movieDAL.GetData(TitleThree);
            List<MovieModel> ShowTimes = new List<MovieModel>();
            ShowTimes.Add(result);
            ShowTimes.Add(result2);
            ShowTimes.Add(result3);
            return View(ShowTimes);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
