namespace BackendTools.Common.Models;

public enum OperationErrorType
{
    None = 500,
    Validation = 400,
    NotFound = 404,
    Forbidden = 403,
    Internal = 500
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

            _ => "Не определено"
        };
}