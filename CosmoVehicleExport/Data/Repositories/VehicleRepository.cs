using CosmoVehicleExport.Domain.Models;
using CosmoVehicleExport.Responses;
using CosmoVehicleExport.Responses.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CosmoVehicleExport.Data.Repositories;

public class VehicleRepository(VehicleDbContext context)
{
    public async Task<IResponse<Vehicle>> Get(string id)
    {
        try
        {
            var model = await context.Vehicles.FindAsync(id);

            if (model is null)
            {
                return new NotFoundResponse<Vehicle>($"vehicle with id {id} not found");
            }

            return new SuccessResponse<Vehicle>(model);
        }
        catch (Exception e)
        {
            return new ExceptionResponse<Vehicle>(e);
        }
    }

    public async Task<IResponse<List<Vehicle>>> Get()
    {
        try
        {
            var model = await context.Vehicles.ToListAsync();

            return new SuccessResponse<List<Vehicle>>(model);
        }
        catch (Exception e)
        {
            return new ExceptionResponse<List<Vehicle>>(e);
        }
    }
}
