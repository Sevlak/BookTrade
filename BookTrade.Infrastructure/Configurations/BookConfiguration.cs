using BookTrade.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookTrade.Infrastructure.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(b => b.Title).IsRequired().HasMaxLength(200).IsUnicode();
        builder.Property(b => b.Author).IsRequired().HasMaxLength(100).IsUnicode();
        builder.Property(b => b.Description).HasMaxLength(500).IsUnicode();
        builder.Property(b => b.PublishedOn).IsRequired();
        builder.Property(b => b.Condition).HasConversion<string>().IsRequired();
        builder.Property(b => b.Categories).HasConversion<string>().IsRequired();
    }
}