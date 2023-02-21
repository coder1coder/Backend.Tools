namespace BackendTools.Common.Models;

public sealed class Result<T>: Result
{
    public T Data { get; }

    private Result(T value)
    {
        Data = value;
    }

    private Result(ResultErrors errors):base(errors)
    {
    }

    public static Result<T> FromValue(T value) => new(value);

    public new static Result<T> FromErrors(ResultErrors errors) => new(errors);

    public new static Result<T> NotFound(string errorMessage, string key = DefaultErrorKeys.NotFound) =>
        FromErrors(Result.NotFound(errorMessage, key).Errors);

    public new static Result<T> Forbidden(string errorMessage, string key = DefaultErrorKeys.Forbidden) =>
        FromErrors(Result.Forbidden(errorMessage, key).Errors);

    public new static Result<T> Internal(string errorMessage, string key = DefaultErrorKeys.Internal) =>
        FromErrors(Result.Internal(errorMessage, key).Errors);

    public new static Result<T> NotValid(Dictionary<string, string> errors = default) =>
        FromErrors(Result.NotValid(errors).Errors);

    public new static Result<T> NotValid(string errorMessage, string key = DefaultErrorKeys.ValidationError) =>
        FromErrors(Result.NotValid(errorMessage, key).Errors);
}