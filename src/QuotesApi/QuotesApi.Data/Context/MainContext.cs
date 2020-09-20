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

            modelBuilder.Entity<Subject>().HasData(
            new Subject[] {
                new Subject {Id = 1, Title = "Education"},
                new Subject {Id = 2, Title = "Programming"}
            });

            modelBuilder.Entity<Quote>().HasData(
                new Quote[]{
                    new Quote()
                    {
                        Id = 1,
                        Text = "Душа, помещенная в тело, подобна неограненному алмазу, " +
                               "и она должна быть отполирована, иначе она никогда не сможет засиять; и очевидно, " +
                               "что если разум отличает нас от животных, " +
                               "то образованность делает это отличие еще большим и помогает нам уйти от животных дальше, чем другие",
                        Author = "Даниэль Дефо",
                        SubjectId = 1
                    }, new Quote
                    {
                        Id = 2,
                        Text = "Кроме высшего образования надо иметь хотя бы среднюю сообразительность",
                        Author = "Николай Леонов",
                        SubjectId = 1
                    }, new Quote
                    {
                        Id = 3,
                        Text =
                            "Не нужно доказывать, что образование – самое великое благо для человека. Без образования люди и грубы, и бедны, и несчастны",
                        Author = "Николай Чернышевский",
                        SubjectId = 1
                    }, new Quote
                    {
                        Id = 4,
                        Text = "Образование – это долг, который настоящее поколение должно уплатить будущему",
                        Author = "Джордж Пибоди",
                        SubjectId = 1
                    }, new Quote
                    {
                        Id = 5,
                        Text = "Образование делает хорошего человека лучше, а плохого – хуже",
                        Author = "Томас Фуллер",
                        SubjectId = 1
                    }, new Quote
                    {
                        Id = 6,
                        Text =
                            "Программирование на С похоже на быстрые танцы на только что отполированном полу людей с острыми бритвами в руках",
                        Author = "Waldi Ravens",
                        SubjectId = 2
                    }, new Quote
                    {
                        Id = 7,
                        Text = "Perl — это тот язык, который одинаково выглядит как до, так и после RSA шифрования",
                        Author = "Keith Bostic",
                        SubjectId = 2
                    }, new Quote
                    {
                        Id = 8,
                        Text =
                            "Я думаю, что Microsoft назвал технологию .NET для того, чтобы она не показывалась в списках директорий Unix",
                        Author = "Даниэль Дефо",
                        SubjectId = 2
                    }, new Quote
                    {
                        Id = 9,
                        Text = "Java — это C++, из которого убрали все пистолеты, ножи и дубинки",
                        Author = "James Gosling",
                        SubjectId = 2
                    }, new Quote
                    {
                        Id = 10,
                        Text = "Помните, что обычно есть решение проще и быстрее того, что первым приходит вам в голову",
                        Author = "Donald Knuth",
                        SubjectId = 2
                    }
                });
        }
    }
}