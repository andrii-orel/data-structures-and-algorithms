using ArraysAndStrings;

namespace Tests;

public class GreedyServiceTests
{
    private readonly IGreedyService _greedyService = new GreedyService();

    [Fact]
    public void GetAverages_Example1_Success()
    {
        // Arrange
        var input = new[] { 1,3,2,4,1 };
        var coins = 7;
        var expected = 4;

        // Act
        var result = _greedyService.MaxIceCream(input, coins);

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetAverages_Example2_Success()
    {
        // Arrange
        var input = new[] { 10,6,8,7,7,8 };
        var coins = 5;
        var expected = 0;

        // Act
        var result = _greedyService.MaxIceCream(input, coins);

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetAverages_Example3_Success()
    {
        // Arrange
        var input = new[] { 1,6,3,1,2,5 };
        var coins = 20;
        var expected = 6;

        // Act
        var result = _greedyService.MaxIceCream(input, coins);

        // Assert
        Assert.Equal(expected, result);
    }
}