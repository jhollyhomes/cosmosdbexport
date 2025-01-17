using CosmoVehicleExport.Responses.Interfaces;

namespace CosmoVehicleExport.Responses;

public class ValidationResponse<T> : IResponse<T>
{
    public ValidationResponse(string message)
    {
        Error = message;
        IsValidationFailure = true;
    }

    public bool IsSuccess { get; } = false;
    public bool IsNotFound { get; } = false;
    public bool IsExceptionFailure { get; } = false;
    public bool IsValidationFailure { get; }
    public T? Data { get; } = default!;
    public string Error { get; }
}
