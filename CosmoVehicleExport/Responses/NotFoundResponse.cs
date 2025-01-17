using CosmoVehicleExport.Responses.Interfaces;

namespace CosmoVehicleExport.Responses;

public class NotFoundResponse<T> : IResponse<T>
{
    public NotFoundResponse(string message)
    {
        IsNotFound = true;
        Error = message;
    }

    public bool IsSuccess { get; } = false;
    public bool IsNotFound { get; }
    public bool IsExceptionFailure { get; } = false;
    public bool IsValidationFailure { get; } = false;
    public T? Data { get; } = default!;
    public string Error { get; }
}