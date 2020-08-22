using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.Models
{
    public interface IQuoteRepository
    {
        IQueryable<Quote> Quotes { get; }
        IQueryable<Theme> Themes { get; }
        IQueryable<QuoteOnVerification> QuotesOnVerification { get; }
        IQueryable<ThemeOnVerification> ThemesOnVerification { get; }

        bool AddQuote(QuoteOnVerification quote);
        bool AddTheme(ThemeOnVerification theme);
    }
}
