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

        public async Task<bool> AddQuote(QuoteOnVerification quote)
        {
            if (await CheckingQuoteExistence(quote))
                return false;

            db.QuotesOnVerification.Add(quote);
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AddTheme(ThemeOnVerification theme)
        {
            if (!await Themes.AnyAsync(t => t.Name.Trim(' ', '.').ToLower() == theme.Name.Trim(' ', '.').ToLower()) &&
                !await ThemesOnVerification.AnyAsync(t => t.Name.Trim(' ', '.').ToLower() == theme.Name.Trim(' ', '.').ToLower()))
                return false;

            db.ThemesOnVerification.Add(theme);
            await db.SaveChangesAsync();

            return true;
        }

        private async Task<bool> CheckingQuoteExistence(QuoteOnVerification quote)
        {
            string text = quote.Text.Trim(' ', '.', '!', '?').Replace(" ", "").ToLower();

            if (await Quotes.AnyAsync(q => q.Text.Trim(' ', '.', '!', '?').Replace(" ", "").ToLower() == text) &&
                await QuotesOnVerification.AnyAsync(q => q.Text.Trim(' ', '.', '!', '?').Replace(" ", "").ToLower() == text) && 
                !await Themes.AnyAsync(t => t.Name.Trim(' ', '.').ToLower() == quote.Theme.Trim(' ', '.').ToLower()) && 
                !await ThemesOnVerification.AnyAsync(t => t.Name.Trim(' ', '.').ToLower() == quote.Theme.Trim(' ', '.').ToLower()))
                return false;

            return true;
        }
    }
}
