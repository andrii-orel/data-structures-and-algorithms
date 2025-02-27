using ArraysAndStrings;

namespace Tests;

public class IntervalsServiceTests
{
    private readonly IIntervalsService _intervalsService;

    public IntervalsServiceTests()
    {
        _intervalsService = new IntervalsService();
    }
[Fact]
    public void Insert_Example1_Success()
    {
        // Input: intervals = [[1,3],[6,9]], newInterval = [2,5]
        // Output: [[1,5],[6,9]]
        // Arrange
        var input = new int[][] { [1,3],[6,9] };
        var newInterval = new int[] { 2, 5 };
        var expected = new int[][] { [1,5],[6,9] };

        // Act
        var result = _intervalsService.Insert(input, newInterval);

        // Assert
        Assert.Equal(expected.Length, result.Length);
        for (int i = 0; i < expected.Length; i++)
        {
            for (int j = 0; j < expected[i].Length; j++)
            {
                Assert.Equal(expected[i][j], result[i][j]);
            }
        }
    }
    [Fact]
    public void Merge_Example1_Success()
    {
        // Input: intervals = [[1,3],[2,6],[8,10],[15,18]]
        // Output: [[1,6],[8,10],[15,18]]
        // Arrange
        var input = new int[][] { [1, 3], [2, 6], [8, 10], [15, 18] };
        var expected = new int[][] { [1, 6], [8, 10], [15, 18] };

        // Act
        var result = _intervalsService.Merge(input);

        // Assert
        Assert.Equal(expected.Length, result.Length);
        for (int i = 0; i < expected.Length; i++)
        {
            for (int j = 0; j < expected[i].Length; j++)
            {
                Assert.Equal(expected[i][j], result[i][j]);
            }
        }
    }

    [Fact]
    public void SummaryRanges_Example1_Success()
    {
        // Input: nums = [0,1,2,4,5,7]
        // Output: ["0->2","4->5","7"]
        // Arrange
        var input = new int[] { 0, 1, 2, 4, 5, 7 };
        var expected = new List<string> { "0->2", "4->5", "7" };

        // Act
        var result = _intervalsService.SummaryRanges(input);

        // Assert
        Assert.Equal(expected, result);
    }
}