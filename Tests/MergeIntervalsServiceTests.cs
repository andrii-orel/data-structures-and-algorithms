using ArraysAndStrings;

namespace Tests;

public class MergeIntervalsServiceTests
{
    private readonly IMergeIntervalsService _mergeIntervalsService;

    public MergeIntervalsServiceTests()
    {
        _mergeIntervalsService = new MergeIntervalsService();
    }
    
    [Fact]
    public void SaveDrop_Example1_Success()
    {
        // Arrange
        var input = new PaintDrop { Start = 0, End = 1 };
        
        // Act
        var result = _mergeIntervalsService.SaveDrop(input);

        // Assert
        Assert.True(result);
    }
}