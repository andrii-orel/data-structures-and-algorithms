using ArraysAndStrings;

namespace Tests;

public class SlidingWindowServiceTests
{
    private readonly ISlidingWindowService _slidingWindowService;

    public SlidingWindowServiceTests()
    {
        _slidingWindowService = new SlidingWindowService();
    }

    [Fact]
    public void FindLength_Example1_Success()
    {
        // Arrange
        int[] input = [3, 1, 2, 7, 4, 2, 1, 1, 5];
        int k = 8;
        int expected = 4;

        // Act
        var result = _slidingWindowService.FindLength(input, k);

        // Assert
        Assert.Equal(expected: expected, actual: result);
    }

    [Fact]
    public void FindMaxAverage_Example1_Success()
    {
        // Arrange
        int[] input = [1, 12, -5, -6, 50, 3];
        int k = 4;
        double expected = 12.75000;

        // Act
        var result = _slidingWindowService.FindMaxAverage(input, k);

        // Assert
        Assert.Equal(expected: expected, actual: result);
    }

    [Fact]
    public void FindMaxAverage_Example2_Success()
    {
        // Arrange
        int[] input = [5];
        int k = 1;
        double expected = 5;

        // Act
        var result = _slidingWindowService.FindMaxAverage(input, k);

        // Assert
        Assert.Equal(expected: expected, actual: result);
    }

    [Fact]
    public void FindMaxAverage2_Example1_Success()
    {
        // Arrange
        int[] input = [1, 12, -5, -6, 50, 3];
        int k = 4;
        double expected = 12.75000;

        // Act
        var result = _slidingWindowService.FindMaxAverage2(input, k);

        // Assert
        Assert.Equal(expected: expected, actual: result);
    }

    [Fact]
    public void FindMaxAverage2_Example2_Success()
    {
        // Arrange
        int[] input = [5];
        int k = 1;
        double expected = 5;

        // Act
        var result = _slidingWindowService.FindMaxAverage2(input, k);

        // Assert
        Assert.Equal(expected: expected, actual: result);
    }

    [Fact]
    public void LongestOnes_Example1_Success()
    {
        // Arrange
        int[] input = [1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0];
        int k = 2;
        int expected = 6;

        // Act
        var result = _slidingWindowService.LongestOnes(input, k);

        // Assert
        Assert.Equal(expected: expected, actual: result);
    }

    [Fact]
    public void LongestOnes_Example2_Success()
    {
        // Arrange
        int[] input = [0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1];
        int k = 3;
        int expected = 10;

        // Act
        var result = _slidingWindowService.LongestOnes(input, k);

        // Assert
        Assert.Equal(expected: expected, actual: result);
    }
}