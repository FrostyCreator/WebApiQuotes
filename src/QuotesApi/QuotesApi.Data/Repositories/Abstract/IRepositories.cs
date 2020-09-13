using QuotesApi.Data.Models.Models;

namespace QuotesApi.Data.Repositories.Abstract
{
    public interface IQuoteRepository : IBaseRepository<Quote>
    {
    }

    public interface ISubjectRepository : IBaseRepository<Subject>
    {
    }
}