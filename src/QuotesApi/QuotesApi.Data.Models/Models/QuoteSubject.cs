namespace QuotesApi.Data.Models.Models
{
    public class QuoteSubject
    {
        public uint QuoteId { get; set; }
        public Quote Quote { get; set; }

        public uint SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}