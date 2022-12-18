namespace BackendTools.Common.Models;

public static class DefaultErrorKeys
{
    public const string NotFound = "not-found";
    public const string Internal = "internal";
    public const string ValidationError = "validation-error";
}

public sealed class Result<T>: Result
{
    public T Data { get; }

    private Result(T value)
    {
        Data = value;
    }

    public static Result<T> Success(T value) => new(value);

    public new static Result<T> NotFound(string errorMessage, string key = DefaultErrorKeys.NotFound) =>
        (Result<T>)Result.NotFound(errorMessage, key);

    public new static Result<T> Internal(string errorMessage, string key = DefaultErrorKeys.Internal) =>
        (Result<T>)Result.Internal(errorMessage, key);

    public new static Result<T> NotValid(Dictionary<string, string> errors = default) =>
        (Result<T>)Result.NotValid(errors);
    public new static Result<T> NotValid(string errorMessage, string key = DefaultErrorKeys.ValidationError) =>
        (Result<T>)Result.NotValid(errorMessage, key);
}

public class Result
{
    public ResultErrors Errors { get; }

    public bool IsSuccess => Errors == null || Errors.Values.Count == 0;

    protected Result(OperationErrorType errorType, IDictionary<string, string> errors)
    {
        Errors =
            new ResultErrors(errorType)
            {
                Values = errors
            };
    }

    protected Result()
    {
    }

    public static Result Success() => new();

    public static Result NotFound(string errorMessage, string key = DefaultErrorKeys.NotFound) =>
        new(OperationErrorType.NotFound, new Dictionary<string, string>
        {
            { key, errorMessage }
        });

    public static Result Internal(string errorMessage, string key = DefaultErrorKeys.Internal) =>
        new(OperationErrorType.Internal, new Dictionary<string, string>
        {
            {key, errorMessage}
        });

    public static Result NotValid(Dictionary<string, string> errors = default) =>
        new(OperationErrorType.Validation, errors);

    public static Result NotValid(string errorMessage, string key = DefaultErrorKeys.ValidationError) =>
        new(OperationErrorType.Validation, new Dictionary<string, string>
        {
            {key, errorMessage}
        });
}