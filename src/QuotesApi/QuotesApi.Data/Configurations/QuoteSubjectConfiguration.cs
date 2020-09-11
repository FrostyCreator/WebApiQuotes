using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuotesApi.Data.Models.Models;

namespace QuotesApi.Data.Configurations
{
    public class QuoteSubjectConfiguration : IEntityTypeConfiguration<QuoteSubject>
    {
        public void Configure(EntityTypeBuilder<QuoteSubject> builder)
        {
            builder.HasKey(key => new {key.QuoteId, key.SubjectId});

            builder.HasOne(q => q.Quote)
                .WithMany(qs => qs.QuotesSubjects)
                .HasForeignKey(k => k.QuoteId);

            builder.HasOne(s => s.Subject)
                .WithMany(qs => qs.QuotesSubjects)
                .HasForeignKey(k => k.SubjectId);

            builder.Property(p => p.QuoteId)
                .HasColumnName("quote_id");

            builder.Property(p => p.SubjectId)
                .HasColumnName("subj_id");
        }
    }
}