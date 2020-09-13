using Microsoft.EntityFrameworkCore;
using QuotesApi.Data.Configurations;
using QuotesApi.Data.Models.Models;

namespace QuotesApi.Data.Context
{
    public sealed class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new QuoteConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
        }
    }
}