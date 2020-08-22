using Microsoft.EntityFrameworkCore;
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

        public IQueryable<QuoteOnVerification> QuotesOnVerification => db.QuotesOnVerification;

        public IQueryable<ThemeOnVerification> ThemesOnVerification => db.ThemesOnVerification;

        public bool AddQuote(QuoteOnVerification quote)
        {
            if (!CheckingQuoteExistence(quote))
                return false;

            db.QuotesOnVerification.Add(quote);
            db.SaveChangesAsync();

            return true;
        }

        public bool AddTheme(ThemeOnVerification theme)
        {
            if (Themes.Any(t => t.Name.ToLower() == theme.Name))
                return false;

            db.ThemesOnVerification.Add(theme);
            db.SaveChangesAsync();

            return true;
        }

        private bool CheckingQuoteExistence(QuoteOnVerification quote)
        {
            string text = quote.Text.ToLower();
            string theme = quote.Theme.ToLower();

            if (Quotes.Any(q => q.Text.ToLower() == text) ||
                !Themes.Any(t => t.Name.ToLower() == theme))
                    return false;

            return true;
        }
    }
}
