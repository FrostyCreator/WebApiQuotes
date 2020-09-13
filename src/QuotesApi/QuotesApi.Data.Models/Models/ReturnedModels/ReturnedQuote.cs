namespace QuotesApi.Data.Models.Models.ReturnedModels
{
    public class ReturnedQuote : BaseEntity
    {
        public string Text { get; set; }
        public string Author { get; set; }
        public string Subject { get; set; }
    }
}