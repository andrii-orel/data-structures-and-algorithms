using Matrices;

namespace Tests;

public class MatrixServiceTests
{
    private readonly IMatrixService _matrixService = new MatrixService();

    [Fact]
    public void OrangesRotting_Example1_Success()
    {
        // Arrange
        var input = new int[][]{[2,1,1],[1,1,0],[0,1,1]};//[[2,1,1],[1,1,0],[0,1,1]]
        var expected = 4;

        // Act
        var result = _matrixService.OrangesRotting(input);

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GameOfLife_Example1_Success()
    {
        // Arrange
        var input = new int[][]{[0,1,0],[0,0,1],[1,1,1],[0,0,0]};//[[0,1,0],[0,0,1],[1,1,1],[0,0,0]]
        var expected = new int[][]{[0,0,0],[1,0,1],[0,1,1],[0,1,0]};//[[0,0,0],[1,0,1],[0,1,1],[0,1,0]]

        // Act
        _matrixService.GameOfLife(input);

        // Assert
        for (int i = 0; i < expected.Length; i++)
        {
            for (int j = 0; j < expected[i].Length; j++)
            {
                Assert.Equal(expected[i][j], input[i][j]);
            }
        }
    }
    
    [Fact]
    public void GameOfLife_Example2_Success()
    {
        // Arrange
        var input = new int[][]{[1,1],[1,0]};
        var expected = new int[][]{[1,1],[1,1]};

        // Act
        _matrixService.GameOfLife(input);

        // Assert
        for (int i = 0; i < expected.Length; i++)
        {
            for (int j = 0; j < expected[i].Length; j++)
            {
                Assert.Equal(expected[i][j], input[i][j]);
            }
        }
    }
}