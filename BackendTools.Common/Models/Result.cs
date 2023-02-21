namespace BackendTools.Common.Models;

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

    protected Result(ResultErrors errors)
    {
        Errors = errors;
    }

    protected Result()
    {
    }

    public static Result Success => new();

    public static Result FromErrors(ResultErrors errors) => new(errors);

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

    public static Result Forbidden(string errorMessage, string key = DefaultErrorKeys.Forbidden) =>
        new(OperationErrorType.Forbidden, new Dictionary<string, string>
        {
            {key, errorMessage}
        });
}