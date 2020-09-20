using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using QuotesApi.Data.Context;
using QuotesApi.Data.Models.Models;
using QuotesApi.Data.Repositories.Abstract;

namespace QuotesApi.Data.Repositories
{
    public class QuoteRepository : BaseRepository<Quote>, IQuoteRepository
    {
        public QuoteRepository(MainContext db)
            : base(db)
        {
        }

        public override IEnumerable<Quote> GetAll()
        {
            return db.Quotes.Include(q => q.Subject);
        }

        public override Quote GetById(int id)
        {
            return db.Quotes.Include(q => q.Subject).FirstOrDefault(q => q.Id == id);
        }

        public override Quote Get(Expression<Func<Quote, bool>> predicate)
        {
            return db.Quotes.Include(q => q.Subject).FirstOrDefault(predicate);
        }

        public override IEnumerable<Quote> GetMany(Expression<Func<Quote, bool>> predicate)
        {
            return db.Quotes.Where(predicate).Include(q => q.Subject);
        }

        public override bool Add(Quote quote)
        {
            if (db.Subjects.Any(s => s.Id == quote.SubjectId) &&
                !db.Quotes.Any(q => q.Text == quote.Text))
            {
                quote.Id = GetNextId();
                db.Quotes.Add(quote);

                return true;
            }

            return false;
        }
    }
}