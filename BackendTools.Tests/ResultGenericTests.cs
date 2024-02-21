using BackendTools.Result;
using Xunit;

namespace BackendTools.Tests;

public class ResultGenericTests
{
    [Fact]
    public void NotFound_ShouldNotBeNull()
    {
        var result = Result<int>.NotFound("Error message");
        Assert.NotNull(result);
    }
}