using System.Collections.Generic;

namespace QuotesApi.Data.Models.Models
{
    public class Quote : BaseEntity
    {
        public string Text { get; set; }
        public string Author { get; set; }
        public ICollection<QuoteSubject> QuotesSubjects { get; set; }
    }
}