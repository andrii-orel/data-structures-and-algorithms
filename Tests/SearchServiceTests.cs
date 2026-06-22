using MathProblems;

namespace Tests;

public class SearchServiceTests
{
    private readonly ISearchService _searchService;

    public SearchServiceTests()
    {
        _searchService = new SearchService();
    }

    [Fact]
    public void ShipWithinDays_Example1_Success()
    {
        // Arrange
        var input = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var days = 5;
        var expected = 15;

        // Act
        var actual = _searchService.ShipWithinDays(input, days);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ShipWithinDays_Example2_Success()
    {
        // Arrange
        var input = new[] { 10,50,100,100,50,100,100,100 };
        var days = 5;
        var expected = 160;

        // Act
        var actual = _searchService.ShipWithinDays(input, days);

        // Assert
        Assert.Equal(expected, actual);
    }
}