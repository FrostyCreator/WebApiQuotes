using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using QuotesApi.Data.Context;
using QuotesApi.Data.Models.Models;

namespace QuotesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuoteController : Controller
    {
        private MainContext db = new MainContext();
        [HttpGet]
        public IEnumerable<Quote> Get()
        {
            return db.Quotes;
        }
    }
}