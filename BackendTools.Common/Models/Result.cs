namespace BackendTools.Common.Models;

public class Result<T>
{
    public T Data { get; }
    public ResultErrors Errors { get; }

    public bool IsSuccess => Errors == null || Errors.Values.Count == 0;

    public Result(T data) => Data = data;

    private Result(OperationErrorType errorType, IDictionary<string, string> errors)
    {
        Errors =
            new ResultErrors(errorType)
            {
                Values = errors
            };
    }

    public static Result<T> Success(T value) => new(value);

    public static Result<T> NotFound(string errorMessage, string key = "not-found") =>
        new(OperationErrorType.NotFound, new Dictionary<string, string>
        {
            { key, errorMessage }
        });

    public static Result<T> NotValid(Dictionary<string, string> errors = default) =>
        new(OperationErrorType.Validation, errors);

    public static Result<T> NotValid(string errorMessage, string key = "validation-error") =>
        new(OperationErrorType.Validation, new Dictionary<string, string>
        {
            {key, errorMessage}
        });
}