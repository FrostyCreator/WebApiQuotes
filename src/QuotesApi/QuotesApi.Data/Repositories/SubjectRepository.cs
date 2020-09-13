using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuotesApi.Data.Context;
using QuotesApi.Data.Models.Models;
using QuotesApi.Data.Repositories.Abstract;

namespace QuotesApi.Data.Repositories
{
    public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(MainContext db)
            : base(db)
        {
        }

        public override IEnumerable<Subject> GetAll()
        {
            return db.Subjects.Include(s => s.Quote);
        }

        public override Subject GetById(uint id)
        {
            return db.Subjects.Include(s => s.Quote).FirstOrDefault(s => s.Id == id);
        }
    }
}