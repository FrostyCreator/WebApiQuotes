using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuotesApi.Data.Models.Models;

namespace QuotesApi.Data.Configurations
{
    public class QuoteConfiguration : IEntityTypeConfiguration<Quote>
    {
        public void Configure(EntityTypeBuilder<Quote> builder)
        {
            builder.HasKey(key => key.Id)
                .HasName("quote_id");
        }
    }
}