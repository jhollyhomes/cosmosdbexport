using CosmoVehicleExport.Contracts;
using CosmoVehicleExport.Domain.Models;

namespace CosmoVehicleExport.Services.Mapping;

public static class VehicleMapper
{
    public static VehicleResponse? MapToVehicleResponse(this Vehicle? model)
    {
        if (model is null) return null;

        return new VehicleResponse(model.Id, 
            model.PartitionKey,
            model.Vrm,
            model.IsUk.Value,
            model.Make,
            model.Model,
            model.Colour,
            model.Type,
            model.TaxClass.Value);
    }
    public static List<VehicleResponse> MapToVehicleListResponse(this List<Vehicle> data)
    {
        if (data.Count == 0) return [];

        return data.Select(x => new VehicleResponse(x.Id,
                x.PartitionKey,
                x.Vrm,
                x.IsUk.Value,
                x.Make,
                x.Model,
                x.Colour,
                x.Type,
                x.TaxClass.Value))
            .ToList();
    }
}

