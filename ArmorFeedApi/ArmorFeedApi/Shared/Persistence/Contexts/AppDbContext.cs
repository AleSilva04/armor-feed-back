using ArmorFeedApi.Customers.Domain.Models;
using ArmorFeedApi.Enterprises.Domain.Models;
using ArmorFeedApi.Payments.Domain.Model;
using ArmorFeedApi.Shared.Extensions;
using ArmorFeedApi.Shipments.Domain.Models;
using ArmorFeedApi.Vehicles.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ArmorFeedApi.Shared.Persistence.Contexts;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Shipment> Shipments { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Enterprise> Enterprises { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

    public DbSet<Customer> Customers{ get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Vehicles
        //vehicles
        builder.Entity<Vehicle>().ToTable("Vehicles");
        builder.Entity<Vehicle>().HasKey(p => p.Id);
        builder.Entity<Vehicle>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Vehicle>().Property(p => p.Brand).IsRequired();
        builder.Entity<Vehicle>().Property(p => p.Year).IsRequired();
        builder.Entity<Vehicle>().Property(p => p.Model).IsRequired();
        builder.Entity<Vehicle>().Property(p => p.LicensePlate).IsRequired();
        builder.Entity<Vehicle>().Property(p => p.VehicleType).IsRequired();
        
        //Relationships
        builder.Entity<Enterprise>()
            .HasMany(p => p.Vehicles)
            .WithOne(p => p.Enterprise)
            .HasForeignKey(p => p.EnterpriseId);

        #endregion
        
        //Apply Snake Case Naming Convention
        builder.UseSnakeCaseNamingConvention();
    }
}