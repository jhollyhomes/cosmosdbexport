using CosmoVehicleExport.Contracts;
using CosmoVehicleExport.Services;
using CsvHelper;
using System.Globalization;

namespace CosmoVehicleExport;

public static class VehicleProcessor
{
    public static async Task OutputVehiclesToCsv(VehicleService vehicleService)
    {
        var response = await vehicleService.GetVehicles();

        if (response.IsSuccess)
        {
            var vehicles = response.Data!;

            DisplayVehiclesOnScreen(vehicles);
            await ExportToCsv(vehicles);
        }
        else
        {
            Console.WriteLine("Error encountered");
            Console.WriteLine(response.Error);
        }
    }

    private static async Task ExportToCsv(List<VehicleResponse> vehicles)
    {
        var fileName = $@"c:\temp\vehicles_{DateTime.Now.ToFileTime()}.csv";

        await using var writer = new StreamWriter(fileName);
        await using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        {
            await csv.WriteRecordsAsync(vehicles);
        }

        Console.WriteLine($"{vehicles.Count} written to CSV file: {fileName}");
    }

    private static void DisplayVehiclesOnScreen(List<VehicleResponse> vehicles)
    {
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine(vehicle.ToString());
        }

        Console.WriteLine($"{vehicles.Count} total vehicles");
    }
}