namespace BackendTools.Common.Models;

public class Page<T>
{
    public ICollection<T> Items { get; set; }
    public long Total { get; set; }
}