using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using QuotesApi.Data.Context;
using QuotesApi.Data.Models.Models;

namespace QuotesApi.Data.Repositories
{
    public class QuoteDbInitializer
    {
        private static MainContext context;

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<MainContext>();
                InitializeQuotes(context);
            }
        }

        private static void InitializeQuotes(MainContext db)
        {
            #region Add Subjects

            if (!db.Subjects.Any())
            {
                var subj1 = new Subject {Title = "Education"};
                var subj2 = new Subject {Title = "Programming"};

                db.Subjects.AddRange(subj1, subj2);
                db.SaveChanges();
            }

            #endregion

            #region Add quotes

            if (!db.Quotes.Any())
            {
                var quotes = new List<Quote>();
                quotes.Add(new Quote
                {
                    Text = "Душа, помещенная в тело, подобна неограненному алмазу, " +
                           "и она должна быть отполирована, иначе она никогда не сможет засиять; и очевидно, " +
                           "что если разум отличает нас от животных, " +
                           "то образованность делает это отличие еще большим и помогает нам уйти от животных дальше, чем другие",
                    Author = "Даниэль Дефо",
                    SubjectId = 1
                });
                quotes.Add(new Quote
                {
                    Text = "Кроме высшего образования надо иметь хотя бы среднюю сообразительность",
                    Author = "Николай Леонов",
                    SubjectId = 1
                });
                quotes.Add(new Quote
                {
                    Text =
                        "Не нужно доказывать, что образование – самое великое благо для человека. Без образования люди и грубы, и бедны, и несчастны",
                    Author = "Николай Чернышевский",
                    SubjectId = 1
                });
                quotes.Add(new Quote
                {
                    Text = "Образование – это долг, который настоящее поколение должно уплатить будущему",
                    Author = "Джордж Пибоди",
                    SubjectId = 1
                });
                quotes.Add(new Quote
                {
                    Text = "Образование делает хорошего человека лучше, а плохого – хуже",
                    Author = "Томас Фуллер",
                    SubjectId = 1
                });
                quotes.Add(new Quote
                {
                    Text =
                        "Программирование на С похоже на быстрые танцы на только что отполированном полу людей с острыми бритвами в руках",
                    Author = "Waldi Ravens",
                    SubjectId = 2
                });
                quotes.Add(new Quote
                {
                    Text = "Perl — это тот язык, который одинаково выглядит как до, так и после RSA шифрования",
                    Author = "Keith Bostic",
                    SubjectId = 2
                });
                quotes.Add(new Quote
                {
                    Text =
                        "Я думаю, что Microsoft назвал технологию .NET для того, чтобы она не показывалась в списках директорий Unix",
                    Author = "Даниэль Дефо",
                    SubjectId = 2
                });
                quotes.Add(new Quote
                {
                    Text = "Java — это C++, из которого убрали все пистолеты, ножи и дубинки",
                    Author = "James Gosling",
                    SubjectId = 2
                });
                quotes.Add(new Quote
                {
                    Text = "Помните, что обычно есть решение проще и быстрее того, что первым приходит вам в голову",
                    Author = "Donald Knuth",
                    SubjectId = 2
                });

                db.Quotes.AddRange(quotes);
                db.SaveChanges();
            }

            #endregion
        }
    }
}