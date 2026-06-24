using ArraysAndStrings;

namespace Tests;

public class SumServiceTests
{
    private readonly ISumService _sumService = new SumService();

    [Fact]
    public void TwoSumUniquePairsExample1_Success()
    {
        // Arrange
        var input = new List<int> { 1, 5, 1, 5 };
        var target = 6;
        var expected = 1;

        // Act
        var actual = _sumService.TwoSumUniquePairs(input, target);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TwoSumUniquePairs_Example2_Success()
    {
        // Arrange
        var input = new List<int> { 46, 1, 1, 2, 45, 46 };
        var target = 47;
        var expected = 2;

        // Act
        var actual = _sumService.TwoSumUniquePairs(input, target);

        // Assert
        Assert.Equal(expected, actual);
    }
}