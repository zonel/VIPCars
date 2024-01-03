using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VipCars.Domain.Entities;

namespace VipCars.Infrastructure.EntitiesConfiguration;

public class CustomerConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        throw new NotImplementedException();
    }
}