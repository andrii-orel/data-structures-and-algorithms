using ArraysAndStrings;

namespace Tests;

public class PrefixSumServiceTests
{
    private readonly IPrefixSumService _prefixSumService;

    public PrefixSumServiceTests()
    {
        _prefixSumService = new PrefixSumService();
    }

    [Fact]
    public void WaysToSplitArray_Example1_Success()
    {
        // Arrange
        int[] input = [10, 4, -8, 7];
        int expected = 2;

        // Act
        var result = _prefixSumService.WaysToSplitArray(input);

        // Assert
        Assert.Equal(expected: expected, actual: result);
    }

    [Fact]
    public void WaysToSplitArray_Example2_Success()
    {
        // Arrange
        int[] input = [2, 3, 1, 0];
        int expected = 2;

        // Act
        var result = _prefixSumService.WaysToSplitArray(input);

        // Assert
        Assert.Equal(expected: expected, actual: result);
    }
    
    [Fact]
    public void WaysToSplitArray2_Example1_Success()
    {
        // Arrange
        int[] input = [10, 4, -8, 7];
        int expected = 2;

        // Act
        var result = _prefixSumService.WaysToSplitArray2(input);

        // Assert
        Assert.Equal(expected: expected, actual: result);
    }

    [Fact]
    public void WaysToSplitArray2_Example2_Success()
    {
        // Arrange
        int[] input = [2, 3, 1, 0];
        int expected = 2;

        // Act
        var result = _prefixSumService.WaysToSplitArray2(input);

        // Assert
        Assert.Equal(expected: expected, actual: result);
    }
}