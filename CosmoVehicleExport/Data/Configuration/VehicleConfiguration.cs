using CosmoVehicleExport.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CosmoVehicleExport.Data.Configuration;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.HasNoDiscriminator();
        builder.ToContainer("vehicles");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.PartitionKey).ToJsonProperty("partitionKey");
        builder.Property(x => x.Vrm).ToJsonProperty("vrm");
        builder.Property(x => x.IsUk).ToJsonProperty("isUk");
        builder.Property(x => x.Make).ToJsonProperty("make");
        builder.Property(x => x.Model).ToJsonProperty("model");
        builder.Property(x => x.Colour).ToJsonProperty("colour");
        builder.Property(x => x.Type).ToJsonProperty("type");
        builder.Property(x => x.TaxClass).ToJsonProperty("taxClass");
    }
}
