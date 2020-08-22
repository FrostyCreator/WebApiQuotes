using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quotes.Models;
using Quotes.Models.ReturnedModels;
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
        public QuoteController(IQuoteRepository context)
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
                Theme = (ReturnedTheme)q.Theme
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
                Theme = (ReturnedTheme)quote.Theme
            };
            return new ObjectResult(returnedQuote);
        }

        [HttpGet("{theme:alpha}")]
        public ActionResult<IEnumerable<ReturnedQuote>> Get(string theme)
        {
            var quote = db.Quotes.Include(q => q.Theme).Where(q => q.Theme.Name == theme);

            if (quote == null)
                return NotFound();

            var returnedQuote = quote.Select(q => new ReturnedQuote()
            {
                Id = q.Id,
                Text = q.Text,
                Author = q.Author,
                Theme = (ReturnedTheme) q.Theme
            });

            return new ObjectResult(returnedQuote);
        }


        [HttpPost]
        public async Task<ActionResult> AddQuote(QuoteOnVerification quote)
        {
            if (await db.AddQuote(quote))
                return new ObjectResult("The quote was added to the verification list");
            else
                return new ObjectResult(new Error() { Code = 400, Message = "The quote already exists or the theme doesn't exist" });
        }
    }
}
