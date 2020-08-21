using Quotes.Models.ReturnedModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.Models
{
    public class Quote
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Text { get; set; }
        public string Author { get; set; }
        public int ThemeId { get; set; }
        public Theme Theme { get; set; }

        public static explicit operator ReturnedQuote(Quote quote)
        {
            return new ReturnedQuote()
            {
                Id = quote.Id,
                Text = quote.Text,
                Author = quote.Author,
                Theme = (ReturnedTheme) quote.Theme
            };
        }
    }
}
