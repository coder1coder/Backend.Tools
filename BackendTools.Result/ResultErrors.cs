namespace BackendTools.Result;

public class ResultErrors
{
    public OperationErrorType Type { get; }

    public IDictionary<string, string> Values { get; set; } = new Dictionary<string, string>();

    public ResultErrors(OperationErrorType type)
    {
        Type = type;
    }
}