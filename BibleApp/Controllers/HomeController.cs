using BibleApp.Models;
using BibleComonInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BibleApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBibleBookManager _bookManager;


        public HomeController(ILogger<HomeController> logger, IBibleBookManager bookManager)
        {
            _logger = logger;
            _bookManager = bookManager;
        }

        public IActionResult Index()

        {
            List<IBook> books = _bookManager.GetBibleBookList();

            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
