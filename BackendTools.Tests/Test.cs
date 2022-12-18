using BackendTools.Common.Models;

namespace BackendTools.Tests;

public class Test
{
    public Test()
    {
        var s = Get();
    }

    public Result Get()
    {
        return Result.Success;
    }

    public Result<string> Get2()
    {
        return Result<string>.NotFound("");
    }

    public Result Get3(ResultErrors errors)
    {
        return Result.FromErrors(errors);
    }
}