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
        private IQuoteRepository db;
        private readonly Random rnd;
        public QuoteController(IQuoteRepository context)
        {
            db = context;
            rnd = new Random();
        }

        /// <summary>
        /// Return all quotes
        /// </summary>
        [HttpGet("{random:bool?}")]
        public ActionResult<IEnumerable<ReturnedQuote>> Get(bool random = false)
        {
            var quotes = db.Quotes.Include(q => q.Theme).ToList();

            if (random)
            {
                return new ObjectResult((ReturnedQuote) quotes[rnd.Next(0, quotes.Count())]);
            }
            return new ObjectResult(
                quotes.Select(q => new ReturnedQuote()
                {
                    Id = q.Id,
                    Text = q.Text,
                    Author = q.Author,
                    Theme = (ReturnedTheme)q.Theme
                }).OrderBy(q => q.Id));
        }

        /// <summary>
        /// Return a single quote with a certain id
        /// </summary>
        /// <param name="id">Id quote</param>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ReturnedQuote>> Get(int id)
        {
            Quote quote = await db.Quotes.Include(q => q.Theme).FirstOrDefaultAsync(x => x.Id == id);

            if (quote == null)
                return NotFound();

            var returnedQuote = new ReturnedQuote()
            {
                Id = quote.Id,
                Text = quote.Text,
                Author = quote.Author,
                Theme = (ReturnedTheme)quote.Theme
            };
            return new ObjectResult(returnedQuote);
        }

        /// <summary>
        /// Return all quotes with a certain theme
        /// </summary>
        /// <param name="theme"></param>
        /// <param name="random">If random == true, it returns 1 random quote, otherwise it returns all quotes from this theme</param>
        /// <returns></returns>
        [HttpGet("{theme:alpha}/{random:bool?}")]
        public ActionResult<IEnumerable<ReturnedQuote>> Get(string theme, bool random = false)
        {
            var quote = db.Quotes.Include(q => q.Theme).Where(q => q.Theme.Name == theme).ToList();

            if (quote.Count == 0)
                return NotFound();

            if (random)
            {
                ReturnedQuote returnedQuote = (ReturnedQuote)quote[rnd.Next(0, quote.Count())];
                return new ObjectResult(returnedQuote);
            }

            var returnedQuotes = quote.Select(q => new ReturnedQuote()
            {
                Id = q.Id,
                Text = q.Text,
                Author = q.Author,
                Theme = (ReturnedTheme)q.Theme
            });

            return new ObjectResult(returnedQuotes);
        }


        [HttpPost]
        public ActionResult AddQuote(QuoteOnVerification quote)
        {
            if (db.AddQuote(quote))
                return new ObjectResult("The quote was added to the verification list");
            else
                return new ObjectResult(new Error() { Code = 400, Message = "The quote already exists or the theme doesn't exist" });
        }
    }
}
