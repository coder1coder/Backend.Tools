Backend.Tools.Common
-
Some classes and helpers to develop webapi

<details>

<summary>Page</summary>

```c#
public class Page<T>
{
    public ICollection<T> Items { get; set; }
    public long Total { get; set; }
}
```
</details>

<details>

<summary>SortDirection</summary>

```c#
public enum SortDirection: byte
{
    Asc = 0,
    Desc = 1
}
```
</details>

<details>

<summary>GetListParameters</summary>

```c#
public class GetListParameters<TFilter> where TFilter: class
{
public TFilter Filter { get; set; }

    public int Offset { get; set; } = GetListParametersDefaults.Offset;
    public int Limit { get; set; } = GetListParametersDefaults.Limit;
    public string SortBy { get; set; }

    public SortDirection SortDirection { get; set; }
}
```
</details>