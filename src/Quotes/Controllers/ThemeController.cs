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
    public class ThemeController : Controller
    {
        private IQuoteRepository db;
        public ThemeController(IQuoteRepository context)
        {
            db = context;
        }

        /// <summary>
        /// Get all themes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnedTheme>>> Get()
        {
            return await db.Themes.Include(t => t.Quotes).Select(t => new ReturnedTheme
            { 
                Id = t.Id,
                Name = t.Name
            }).ToListAsync();
        }


        [HttpPost]
        public ActionResult AddTheme(ThemeOnVerification theme)
        {
            if (db.AddTheme(theme))
                return new ObjectResult("The quote was added to the verification list");
            else
                return new ObjectResult(new Error() { Code = 400, Message = "The quote already exists or the theme doesn't exist" });
        }
    }
}
