using CosmoVehicleExport;
using CosmoVehicleExport.Data;
using CosmoVehicleExport.Data.Repositories;
using CosmoVehicleExport.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddScoped<VehicleService>();
builder.Services.AddScoped<VehicleRepository>();

builder.Services.AddDbContextFactory<VehicleDbContext>(o =>
{
    o.UseCosmos(
        connectionString: "",
        databaseName: "vehicledata");
    o.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    o.EnableDetailedErrors();
    o.EnableSensitiveDataLogging();
});

using var host = builder.Build();

using var serviceScope = host.Services.CreateScope();
var serviceProvider = serviceScope.ServiceProvider;
var vehicleService = serviceProvider.GetRequiredService<VehicleService>();

await VehicleProcessor.OutputVehiclesToCsv(vehicleService);

await host.RunAsync();