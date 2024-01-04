using Microsoft.EntityFrameworkCore;
using VipCars.Domain.Entities;
using VipCars.Infrastructure.EntitiesConfiguration;

namespace VipCars.Infrastructure.Persistence;

public class VipDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Role> Roles { get; set; }
    
    public VipDbContext(DbContextOptions<VipDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new AddressConfiguration());
        modelBuilder.ApplyConfiguration(new CarConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}