using CosmoVehicleExport.Responses.Interfaces;

namespace CosmoVehicleExport.Responses;

public class ExceptionResponse<T> : IResponse<T>
{
    public ExceptionResponse(string message)
    {
        Error = message;
        IsExceptionFailure = true;
    }

    public ExceptionResponse(Exception exception)
    {
        Error = exception.Message;
        IsExceptionFailure = true;
    }

    public bool IsSuccess { get; } = false;
    public bool IsNotFound { get; } = false;
    public bool IsExceptionFailure { get; }
    public bool IsValidationFailure { get; } = false;
    public T? Data { get; } = default!;
    public string Error { get; }
}