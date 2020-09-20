using QuotesApi.Data.Models.Models.ReturnedModels;

namespace QuotesApi.Data.Models.Models
{
    public class Quote : BaseEntity
    {
        public string Text { get; set; }
        public string Author { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public static explicit operator ReturnedQuote(Quote quote)
        {
            return new ReturnedQuote
            {
                Id = quote.Id,
                Text = quote.Text,
                Author = quote.Author,
                Subject = quote.Subject.Title
            };
        }
    }
}