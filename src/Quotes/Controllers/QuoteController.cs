using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quotes.Models;
using Quotes.Models.ReturnedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class QuoteController : Controller
    {
        private readonly IQuoteRepository db;
        private readonly Random rnd;
        public QuoteController(IQuoteRepository context)
        {
            db = context;
            rnd = new Random();
        }

        /// <summary>
        /// Return all quotes
        /// </summary>
        /// <param name="random">If random = true, it returns 1 random quote, otherwise it returns all quotes</param>
        [HttpGet("{random:bool?}")]
        public ActionResult<IEnumerable<ReturnedQuote>> Get(bool random = false)
        {
            var quotes = db.Quotes.Include(q => q.Theme).ToList();

            if (random)
                return new ObjectResult((ReturnedQuote) quotes[rnd.Next(0, quotes.Count())]);

            return new ObjectResult(quotes.Select(q => (ReturnedQuote) q).OrderBy(q => q.Id));
        }

        /// <summary>
        /// Return a single quote with a certain id
        /// </summary>
        /// <param name="id">Id quote</param>
        /// <response code="201">Return a single quote with a certain id</response>
        /// <response code="400">If quote with this id doesn't exist</response> 
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ReturnedQuote>> Get(int id)
        {
            Quote quote = await db.Quotes.Include(q => q.Theme).FirstOrDefaultAsync(x => x.Id == id);

            if (quote == null)
                return NotFound();

            ReturnedQuote returnedQuote = (ReturnedQuote) quote;

            return new ObjectResult(returnedQuote);
        }

        /// <summary>
        /// Return all quotes with a certain theme
        /// </summary>
        /// <param name="theme">Theme</param>
        /// <param name="random">If random = true, it returns 1 random quote, otherwise it returns all quotes from this theme</param>
        /// <response code="400">If the theme doesn't exist</response>
        [HttpGet("{theme:alpha}/{random:bool?}")]
        public ActionResult<IEnumerable<ReturnedQuote>> Get(string theme, bool random = false)
        {
            var quote = db.Quotes.Include(q => q.Theme).Where(q => q.Theme.Name == theme).ToList();

            if (quote.Count == 0)
                return NotFound();

            if (random)
            {
                ReturnedQuote returnedQuote = (ReturnedQuote) quote[rnd.Next(0, quote.Count())];
                return new ObjectResult(returnedQuote);
            }

            var returnedQuotes = quote.Select(q => (ReturnedQuote) q);
            return new ObjectResult(returnedQuotes);
        }

        [HttpPost]
        public ActionResult AddQuote([FromBody] QuoteOnVerification quote)
        {
            if (db.AddQuote(quote))
                return new ObjectResult("The quote was added to the verification list");
            else
                return new ObjectResult(new Error() { Code = 400, Message = "The quote already exists or the theme doesn't exist" });
        }
    }
}
