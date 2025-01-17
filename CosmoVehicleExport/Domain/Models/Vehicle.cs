namespace CosmoVehicleExport.Domain.Models;

public class Vehicle
{
    public string? Id { get; set; }
    public string? PartitionKey { get; set; }
    public string? Vrm { get; set; }
    public bool? IsUk { get; set; }
    public string? Make { get; set; }
    public string? Model { get; set; }
    public string? Colour { get; set; }
    public string? Type { get; set; }
    public int? TaxClass { get; set; }
}