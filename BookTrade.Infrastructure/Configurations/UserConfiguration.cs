using BookTrade.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookTrade.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.OwnsOne(u => u.Location, locationBuilder =>
        {
            locationBuilder.Property(l => l.ZipCode).HasMaxLength(8);
            locationBuilder.Property(l => l.City).HasMaxLength(50);
        });

        builder.HasMany(u => u.BooksAvailableForTrade).WithMany();

        builder
            .HasMany(u => u.InitiatedTrades)
            .WithOne(u => u.Trader)
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasMany(u => u.ReceivedTrades)
            .WithOne(u => u.TradedWith)
            .OnDelete(DeleteBehavior.SetNull);
    }
}