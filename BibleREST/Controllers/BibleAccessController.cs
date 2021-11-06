using BibleComonInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BibleREST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BibleAccessController : ControllerBase
    {
        private readonly ILogger<BibleAccessController> _logger;
        private readonly IBibleBookManager _bookManager;

        public BibleAccessController(ILogger<BibleAccessController> logger, IBibleBookManager bookManager)
        {
            _logger = logger;
            _bookManager = bookManager;

        }

        [HttpGet]
        public ActionResult BooksGet()
        {
           return Ok(JsonConvert.SerializeObject(_bookManager.GetBibleBookList()));

        }
    }
}
