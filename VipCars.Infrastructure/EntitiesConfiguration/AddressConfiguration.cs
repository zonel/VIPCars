using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VipCars.Domain.Entities;

namespace VipCars.Infrastructure.EntitiesConfiguration;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        // builder.HasMany(a => a.Users)
        //     .WithOne(u => u.Address)
        //     .HasForeignKey(u => u.AddressId);
    }
}