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
        private IQuoteRepository quoteRepository;
        private readonly Random _rnd = new Random();
        public QuoteController(IQuoteRepository quoteRepository)
        {
            this.quoteRepository = quoteRepository;
        }

        [HttpGet("{random:bool?}")]
        public ActionResult<IEnumerable<ReturnedQuote>> Get(bool random = false)
        {
            var quotes = 
                quoteRepository
                    .GetAll()
                    ?.Select(q => (ReturnedQuote) q);

            if (quotes == null)
            {
                return NotFound();
            }
            
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

        [HttpGet("{id:int}")]
        public ActionResult<ReturnedQuote> GetById(uint id)
        {
            var quote = quoteRepository.GetById(id);

            if (quote == null)
            {
                return NotFound();
            }
            return (ReturnedQuote) quoteRepository.GetById(id);
        }

        [HttpGet("{subject:alpha}/{random:bool?}")]
        public ActionResult<IEnumerable<ReturnedQuote>> Get(string subject, bool random = false)
        {
            var quotes = 
                quoteRepository
                    .GetMany(quote => quote.Subject.Title == subject)
                    ?.Select(q => (ReturnedQuote) q);

            if (quotes == null)
            {
                return NotFound();
            }

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

        [HttpPost]
        public IActionResult AddQuote([FromBody] Quote quote)
        {
            if (quoteRepository.Add(quote))
            {
                quoteRepository.Commit();
                
                return new ObjectResult(new Success()
                {
                    Status = 200,
                    Message = "Quote added"
                });
            }
            
            return new ObjectResult(new Error()
            {
                Status = 400,
                Message = "The quote already exists or the theme doesn't exist"
            });
        }
    }
}