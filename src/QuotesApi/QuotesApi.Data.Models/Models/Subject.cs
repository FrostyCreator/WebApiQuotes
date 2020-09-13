using System.Collections.Generic;
using System.Linq;
using QuotesApi.Data.Models.Models.ReturnedModels;

namespace QuotesApi.Data.Models.Models
{
    public class Subject : BaseEntity
    {
        public string Title { get; set; }
        public List<Quote> Quote { get; set; }

        public static explicit operator ReturnedSubject(Subject subject)
        {
            return new ReturnedSubject
            {
                Id = subject.Id,
                Title = subject.Title,
                Quotes = subject.Quote.Select(q => (ReturnedQuote) q).ToList()
            };
        }
    }
}