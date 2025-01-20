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
    
    [Fact]
    public void RunningSum_Example1_Success()
    {
        // Arrange
        int[] input = [1, 2, 3, 4];
        int[] expected = [1,3,6,10];

        // Act
        var result = _prefixSumService.RunningSum(input);

        // Assert
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected: expected[i], actual: result[i]);
        }
    }

    [Fact]
    public void RunningSum_Example2_Success()
    {
        // Arrange
        int[] input = [1,1,1,1,1];
        int[] expected = [1,2,3,4,5];

        // Act
        var result = _prefixSumService.RunningSum(input);

        // Assert
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected: expected[i], actual: result[i]);
        }
    }
    
    [Fact]
    public void RunningSum_Example3_Success()
    {
        // Arrange
        int[] input = [1];
        int[] expected = [1];

        // Act
        var result = _prefixSumService.RunningSum(input);

        // Assert
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected: expected[i], actual: result[i]);
        }
    }
}