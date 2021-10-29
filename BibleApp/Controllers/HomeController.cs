using BibleApp.Models;
using BibleComonInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
            IBook book = _bookManager.GetBook(bookID);
            IChapter chapter = _bookManager.GetChapter(book, chapterNumber);
            PassageViewModel model = new PassageViewModel(_bookManager.GetPassage(book, chapter, verseStart, verseEnd));
            model.MaxChapter = book.ChapterCount;
            model.MaxVerse = chapter.VerseCount;
            return View(model);
        }
        [HttpGet]
        public String PassageUpdate(String bookID, int chapterNumber, int verseStart, int verseEnd)
        {
            IBook book = _bookManager.GetBook(bookID);
            IChapter chapter = _bookManager.GetChapter(book, chapterNumber);
            PassageViewModel model = new PassageViewModel(_bookManager.GetPassage(book, chapter, verseStart, verseEnd));
            model.MaxChapter = book.ChapterCount;
            model.MaxVerse = chapter.VerseCount;
            String result = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            return result;
        }
        [HttpPost]
        public ActionResult AddPassageToUserPassages([FromBody] AddPassageViewModel addPassageViewModel)
        {
            IBook book = _bookManager.GetBook(addPassageViewModel.Book);
            IChapter chapter = _bookManager.GetChapter(book, addPassageViewModel.Chapter);
            _bookManager.AddUserPassage(_bookManager.GetPassage(book, chapter, addPassageViewModel.PassageStart, addPassageViewModel.PassageEnd));
            return Ok();
        }

        public IActionResult ListSavedPassages()
        {
            SavedPassageViewModel model = new SavedPassageViewModel();
            model.Passages = _bookManager.GetPassages();
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
