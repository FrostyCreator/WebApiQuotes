using System.Collections.Generic;

namespace QuotesApi.Data.Models.Models.ReturnedModels
{
    public class ReturnedSubject : BaseEntity
    {
        public string Title { get; set; }
        public List<ReturnedQuote> Quotes { get; set; }
    }
}