using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuotesApi.Data.Configurations;
using QuotesApi.Data.Models.Models;

namespace QuotesApi.Data.Context
{
    public class MainContext : DbContext
    {
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public MainContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;UserId=ruslan;Password=12345678;database=Quote;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new QuoteConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new QuoteSubjectConfiguration());
        }
    }
}