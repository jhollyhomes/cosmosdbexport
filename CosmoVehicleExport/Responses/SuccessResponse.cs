using CosmoVehicleExport.Responses.Interfaces;

namespace CosmoVehicleExport.Responses;


public class SuccessResponse<T> : IResponse<T>
{
    public SuccessResponse()
    {
        IsSuccess = true;
    }
    public SuccessResponse(T data)
    {
        Data = data;
        IsSuccess = true;
    }

    public bool IsSuccess { get; }
    public bool IsNotFound { get; } = false;
    public bool IsExceptionFailure { get; } = false;
    public bool IsValidationFailure { get; } = false;
    public T? Data { get; }
    public string Error { get; } = string.Empty;
}
