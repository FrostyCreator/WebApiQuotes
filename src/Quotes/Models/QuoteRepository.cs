using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.Models
{
    public class QuoteRepository : IQuoteRepository
    {
        private ApplicationContext db;
        public QuoteRepository(ApplicationContext context)
        {
            db = context;
        }
        public IQueryable<Quote> Quotes => db.Quotes;

        public IQueryable<Theme> Themes => db.Themes;


    }
}
