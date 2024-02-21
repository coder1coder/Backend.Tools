namespace BackendTools.Result;

public enum OperationErrorType
{
    Internal = 500,
    Validation = 400,
    NotFound = 404,
    Forbidden = 403,
    Unauthorized = 401
}

public static class OperationErrorTypeExtensions
{
    public static string ToDescription(this OperationErrorType value)
        => value switch
        {
            OperationErrorType.Validation => "Ошибка валидации",
            OperationErrorType.NotFound => "Ресурс не найден",
            OperationErrorType.Forbidden => "Нет доступа",
            OperationErrorType.Internal => "Внутренняя ошибка",
            OperationErrorType.Unauthorized => "Ошибка авторизации",

            _ => "Не определено"
        };
}