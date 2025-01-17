using CosmoVehicleExport.Data;
using CosmoVehicleExport.Data.Repositories;
using CosmoVehicleExport.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CsvHelper;
using System.Globalization;

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

Console.WriteLine("Create service");

using var serviceScope = host.Services.CreateScope();
var services = serviceScope.ServiceProvider;
var vehicleService = services.GetRequiredService<VehicleService>();

Console.WriteLine("Get vehicles");

var response = await vehicleService.GetVehicles();

Console.WriteLine($"{response.Data!.Count} Vehicles found");

foreach (var vehicle in response.Data!)
{
    Console.WriteLine(vehicle.ToString());
}

Console.WriteLine("Write CSV file");

await using (var writer = new StreamWriter($@"c:\temp\vehicles_{DateTime.Now.ToFileTime()}.csv"))

await using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
{
    csv.WriteRecords(response.Data);
}

Console.WriteLine("Complete");

await host.RunAsync();