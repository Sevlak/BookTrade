using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookTrade.Infrastructure.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasOne(u => u.DomainUser)
            .WithOne()
            .IsRequired()
            .HasForeignKey<AppUser>(u => u.DomainUserId);
    }
}