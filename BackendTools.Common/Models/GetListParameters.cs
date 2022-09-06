namespace BackendTools.Common.Models;

public class GetListParameters<TFilter> where TFilter: class
{
    public TFilter Filter { get; set; }

    public int Offset { get; set; } = GetListParametersDefaults.Offset;
    public int Limit { get; set; } = GetListParametersDefaults.Limit;
    public string SortBy { get; set; }

    public SortDirection SortDirection { get; set; }
}

public static class GetListParametersDefaults
{
    public const int Offset = 0;
    public const int Limit = 25;

    public static int PositiveOffsetOrDefault(int offset)
        => offset >= 0 ? offset : Offset;

    public static int PositiveLimitOrDefault(int limit)
        => limit >= 0 ? limit : Limit;
}