using System.Collections.Generic;

namespace QuotesApi.Data.Models.Models
{
    public class Subject : BaseEntity
    {
        public string Title { get; set; }
        public ICollection<QuoteSubject> QuotesSubjects { get; set; }
    }
}