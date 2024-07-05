using ArraysAndStrings;

namespace Tests;

public class TwoPointersServiceTests
{
    private readonly ITwoPointersService _twoPointersService;
    
    public TwoPointersServiceTests()
    {
        _twoPointersService = new TwoPointersService();
    }
    
    [Fact]
    public void ReverseString_Example1_Success()
    {
        // Arrange
        char[] input = ['h', 'e', 'l', 'l', 'o'];
        char[] expected = ['o','l','l','e','h'];
        
        // Act
        _twoPointersService.ReverseString(input);
        
        // Assert
        Assert.NotNull(input);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected: expected[i], actual: input[i]);
        }
    }
    
    [Fact]
    public void ReverseString_Example2_Success()
    {
        // Arrange
        char[] input = ['H','a','n','n','a','h'];
        char[] expected = ['h','a','n','n','a','H'];
        
        // Act
        _twoPointersService.ReverseString(input);
        
        // Assert
        Assert.NotNull(input);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected: expected[i], actual: input[i]);
        }
    }
    
    [Fact]
    public void ReverseStringDefault_Example1_Success()
    {
        // Arrange
        char[] input = ['h', 'e', 'l', 'l', 'o'];
        char[] expected = ['o','l','l','e','h'];
        
        // Act
        var result = _twoPointersService.ReverseStringDefault(input);
        
        // Assert
        Assert.NotNull(result);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected: expected[i], actual: result[i]);
        }
    }
    
    [Fact]
    public void ReverseStringDefault_Example2_Success()
    {
        // Arrange
        char[] input = ['H','a','n','n','a','h'];
        char[] expected = ['h','a','n','n','a','H'];
        
        // Act
        var result = _twoPointersService.ReverseStringDefault(input);
        
        // Assert
        Assert.NotNull(result);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected: expected[i], actual: result[i]);
        }
    }
    
    [Fact]
    public void SortedSquares_Example1_Success()
    {
        // Arrange
        int[] input = [-4,-1,0,3,10];
        int[] expected = [0,1,9,16,100];
        
        // Act
        var result = _twoPointersService.SortedSquares(input);
        
        // Assert
        Assert.NotNull(input);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected: expected[i], actual: result[i]);
        }
    }
    
    [Fact]
    public void SortedSquares_Example2_Success()
    {
        // Arrange
        int[] input = [-7,-3,2,3,11];
        int[] expected = [4,9,9,49,121];
        
        // Act
        var result = _twoPointersService.SortedSquares(input);
        
        // Assert
        Assert.NotNull(input);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected: expected[i], actual: result[i]);
        }
    }
}