using MathProblems;

namespace Tests;

public class MathProblemsServiceTests
{
    private readonly IMathProblemsService _mathProblemsService;

    public MathProblemsServiceTests()
    {
        _mathProblemsService = new MathProblemsService();
    }

    [Fact]
    public void Factorial_Example1_Success()
    {
        // Arrange 5! = 120
        var x = 5;
        var expected = 120;

        // Act
        var result = _mathProblemsService.Factorial(x);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TrailingZeroes_Example1_Success()
    {
        // Arrange
        var x = 3;
        var expected = 0;

        // Act
        var result = _mathProblemsService.TrailingZeroes(x);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void LongestConsecutive_Example1_Success()
    {
        // Arrange
        var x = 2.1;
        var n = 3;
        var expected = 9.261000000000001;

        // Act
        var result = _mathProblemsService.MyPow(x, n);

        // Assert
        Assert.Equal(expected, result);
    }
}