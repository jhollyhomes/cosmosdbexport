namespace CosmoVehicleExport.Contracts;

public class VehicleResponse(string id, string partitionKey, string vrm, bool isUk, string make, string model, string colour, string type, int taxClass)
{
    public string Id { get; set; } = id;
    public string PartitionKey { get; set; } = partitionKey;
    public string Vrm { get; set; } = vrm;
    public bool IsUk { get; set; } = isUk;
    public string Make { get; set; } = make;
    public string Model { get; set; } = model;
    public string Colour { get; set; } = colour;
    public string Type { get; set; } = type;
    public int TaxClass { get; set; } = taxClass;
    
    public override string ToString()
    {
        return $"Vrm: {Vrm}, IsUk: {IsUk}, Make: {Make}, Model: {Model}, Colour: {Colour}, Type: {Type}, Tax Class: {TaxClass}";
    }
}