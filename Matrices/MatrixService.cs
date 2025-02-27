namespace Matrices;

public interface IMatrixService
{
    void GameOfLife(int[][] board);
}

public class MatrixService : IMatrixService
{
    // 289. Game of Life
    // According to Wikipedia's article: "The Game of Life, also known simply as Life, is a cellular automaton devised by the British mathematician John Horton Conway in 1970."
    // The board is made up of an m x n grid of cells, where each cell has an initial state: live (represented by a 1) or dead (represented by a 0). Each cell interacts with its eight neighbors (horizontal, vertical, diagonal) using the following four rules (taken from the above Wikipedia article):
    // 1. Any live cell with fewer than two live neighbors dies as if caused by under-population.
    // 2. Any live cell with two or three live neighbors lives on to the next generation.
    // 3. Any live cell with more than three live neighbors dies, as if by over-population.
    // 4. Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
    //     The next state of the board is determined by applying the above rules simultaneously to every cell in the current state of the m x n grid board. In this process, births and deaths occur simultaneously.
    //     Given the current state of the board, update the board to reflect its next state.
    //     Note that you do not need to return anything.
    public void GameOfLife(int[][] board)
    {
        int rows = board.Length;
        int cols = board[0].Length;
        int[][] temp = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            temp[i] = new int[cols]; // Initialize each row with 'cols' elements
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                int liveNeighbours = CountLiveNeighbours(i, j, rows, cols, board);
                bool isAlive = board[i][j] != 0;
                // 1. Any live cell with fewer than two live neighbors dies as if caused by under-population.
                // 3. Any live cell with more than three live neighbors dies, as if by over-population.
                if (isAlive && (liveNeighbours < 2 || liveNeighbours > 3))
                {
                    temp[i][j] = 0; // Underpopulation or Overpopulation
                }
                // 4. Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
                else if (!isAlive && liveNeighbours == 3)
                {
                    temp[i][j] = 1; // Reproduction
                }
                // 2. Any live cell with two or three live neighbors lives on to the next generation.
                else
                {
                    temp[i][j] = board[i][j]; // Stays the same
                }
            }
        }
        
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                board[i][j] = temp[i][j];
            }
        }
    }
    
    private int CountLiveNeighbours(int row, int col, int rows, int cols, int[][] board)
    {
        int liveCount = 0;
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0)
                    continue; // Skip the cell itself
                
                int x = row + i;
                int y = col + j;
                if (x >= 0 && x < rows && y >= 0 && y < cols && board[x][y] == 1)
                {
                    liveCount++;
                }
            }
        }
        
        return liveCount;
    }
}