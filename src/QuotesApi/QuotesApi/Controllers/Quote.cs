using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QuotesApi.Data.Models.Models;
using QuotesApi.Data.Models.Models.ReturnedModels;
using QuotesApi.Data.Repositories.Abstract;

namespace QuotesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class QuoteController : Controller
    {
        private readonly Random _rnd = new Random();
        private readonly IQuoteRepository quoteRepository;

        public QuoteController(IQuoteRepository quoteRepository)
        {
            this.quoteRepository = quoteRepository;
        }

        /// <summary>
        /// Get all quotes
        /// </summary>
        /// <param name="random">If random == true, return one random quote</param>
        [HttpGet("{random:bool?}")]
        public ActionResult<IEnumerable<ReturnedQuote>> Get(bool random = false)
        {
            var quotes =
                quoteRepository
                    .GetAll()
                    ?.Select(q => (ReturnedQuote) q)
                    .OrderBy(q => q.Id);

            if (quotes == null) return NotFound();

            if (random)
            {
                var returnedQuotes = quotes.ToList();
                return new ObjectResult
                (
                    returnedQuotes.ToList()[_rnd.Next(returnedQuotes.Count)]
                );
            }

            return new ObjectResult(quotes);
        }

        /// <summary>
        /// Get 1 quote with certain id
        /// </summary>
        /// <param name="id">Id quote</param>
        [HttpGet("{id:int}")]
        public ActionResult<ReturnedQuote> GetById(int id)
        {
            var quote = quoteRepository.GetById(id);

            if (quote == null) return NotFound();
            return (ReturnedQuote) quoteRepository.GetById(id);
        }

        /// <summary>
        /// Get all quotes with certain subject
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="random">If random == true, return 1 random quote with certain subject</param>
        /// <returns></returns>
        [HttpGet("{subject:alpha}/{random:bool?}")]
        public ActionResult<IEnumerable<ReturnedQuote>> Get(string subject, bool random = false)
        {
            var quotes =
                quoteRepository
                    .GetMany(quote => quote.Subject.Title.ToLower() == subject.ToLower())
                    ?.Select(q => (ReturnedQuote) q);

            if (quotes == null) return NotFound();

            if (random)
            {
                var returnedQuotes = quotes.ToList();
                return new ObjectResult
                (
                    returnedQuotes.ToList()[_rnd.Next(returnedQuotes.Count)]
                );
            }

            return new ObjectResult(quotes);
        }

        /// <summary>
        /// Add quote
        /// </summary>
        /// <param name="quote"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddQuote([FromBody] Quote quote)
        {
            if (quoteRepository.Add(quote))
            {
                quoteRepository.Commit();

                return new ObjectResult(new Success
                {
                    Status = 200,
                    Message = "Quote added"
                });
            }

            return new ObjectResult(new Error
            {
                Status = 400,
                Message = "The quote already exists or the theme doesn't exist"
            });
        }
    }
}