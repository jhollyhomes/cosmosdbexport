using CosmoVehicleExport.Data.Configuration;
using CosmoVehicleExport.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CosmoVehicleExport.Data;

public class VehicleDbContext(DbContextOptions<VehicleDbContext> options) : DbContext(options)
{
    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new VehicleConfiguration());
    }
}
