using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VipCars.Domain.Entities;

namespace VipCars.Infrastructure.EntitiesConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasOne(u => u.Address)
            .WithMany(a => a.Users)
            .HasForeignKey(u => u.AddressId);

        builder.HasOne(u => u.UserRole)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.UserRoleId);
    }
}