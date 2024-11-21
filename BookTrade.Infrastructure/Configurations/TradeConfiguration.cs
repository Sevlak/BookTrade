using BookTrade.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookTrade.Infrastructure.Configurations;

public class TradeConfiguration : IEntityTypeConfiguration<Trade>
{
    public void Configure(EntityTypeBuilder<Trade> builder)
    {
        builder.HasKey(t => t.Id);
        builder.HasOne(t => t.Trader).WithMany(u => u.InitiatedTrades).IsRequired();
        builder.HasOne(t => t.TradedWith).WithMany(u => u.ReceivedTrades).IsRequired();
        builder.HasOne(t => t.BookToTrade).WithMany().IsRequired();
        builder.HasOne(t => t.TradedFor).WithMany().IsRequired();
        builder.Property(t => t.TradeDate).IsRequired();
        builder.Property(t => t.Status).HasConversion<string>().IsRequired().IsUnicode();
    }
}