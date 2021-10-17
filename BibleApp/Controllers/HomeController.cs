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
            BookListViewModel model = new BookListViewModel();
            model.Books = _bookManager.GetBibleBookList();

            return View(model);
        }

        public IActionResult Book(String id)
        {
            BookViewModel model = new BookViewModel();
            model.Book = _bookManager.GetBook(id);

            return View(model);
        }

        public IActionResult Passage(String bookID, int chapterNumber, int verseStart, int verseEnd)
        {
            PassageViewModel model = new PassageViewModel();
            IBook book = _bookManager.GetBook(bookID);
            IChapter chapter = _bookManager.GetChapter(book, chapterNumber);
            model.Passage =  _bookManager.GetPassage(book, chapter, verseStart, verseEnd);
            return View(model);
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
