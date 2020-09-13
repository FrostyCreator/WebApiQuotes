using System.Collections.Generic;

namespace QuotesApi.Data.Models.Models.ReturnedModels
{
    public class ListErrors
    {
        public List<Error> Errors { get; set; } = new List<Error>();
    }

    public class Error
    {
        public int Status { get; set; }
        public string Message { get; set; }
    }
}