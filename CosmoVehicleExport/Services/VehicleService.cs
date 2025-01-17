using CosmoVehicleExport.Data.Repositories;
using CosmoVehicleExport.Domain.Models;
using CosmoVehicleExport.Responses.Interfaces;
using CosmoVehicleExport.Responses;
using CosmoVehicleExport.Contracts;
using CosmoVehicleExport.Responses.Extensions;
using CosmoVehicleExport.Services.Mapping;

namespace CosmoVehicleExport.Services;

public class VehicleService(VehicleRepository repository)
{
    public async Task<IResponse<VehicleResponse?>> GetVehicle(string id)
    {
        var result = await repository.Get(id);

        if (!result.IsSuccess)
        {
            return result.ReturnFailedResponse<Vehicle, VehicleResponse>();
        }

        return new SuccessResponse<VehicleResponse?>(result.Data.MapToVehicleResponse());
    }

    public async Task<IResponse<List<VehicleResponse>>> GetVehicles()
    {
        var result = await repository.Get();

        if (!result.IsSuccess)
        {
            return result.ReturnFailedResponse<List<Vehicle>, List<VehicleResponse>>();
        }

        return new SuccessResponse<List<VehicleResponse>>(result.Data!.MapToVehicleListResponse());
    }
}
