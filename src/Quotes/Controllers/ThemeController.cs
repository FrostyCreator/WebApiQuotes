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

        private ApplicationContext db;
        public ThemeController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnedTheme>>> Get()
        {
            return await db.Themes.Include(t => t.Quotes).Select(t => new ReturnedTheme
            { 
                Id = t.Id,
                Name = t.Name
            }).ToListAsync();
        }
    }
}
