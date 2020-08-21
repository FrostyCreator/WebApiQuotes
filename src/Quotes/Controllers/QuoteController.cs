using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Quotes.Models;
using Quotes.Models.ReturnedModels;

namespace Quotes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class QuoteController : Controller
    {
        private ApplicationContext db;
        public QuoteController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnedQuote>>> Get()
        {
            return await db.Quotes.Include(q => q.Theme).Select(q => new ReturnedQuote()
            { 
                Id = q.Id,
                Text = q.Text,
                Author = q.Author,
                Theme = (ReturnedTheme) q.Theme
            }).OrderBy(q => q.Id).ToListAsync();
        }

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
                Theme = (ReturnedTheme) quote.Theme
            };
            return new ObjectResult(returnedQuote);
        }
    }
}
