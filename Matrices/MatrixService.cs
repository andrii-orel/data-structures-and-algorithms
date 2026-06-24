namespace Matrices;

public interface IMatrixService
{
    int OrangesRotting(int[][] grid);
    void GameOfLife(int[][] board);
}

public class MatrixService : IMatrixService
{
    // 994. Rotting Oranges
    // Medium
    // You are given an m x n grid where each cell can have one of three values:
    // 0 representing an empty cell,
    // 1 representing a fresh orange, or
    // 2 representing a rotten orange.
    // Every minute, any fresh orange that is 4-directionally adjacent to a rotten orange becomes rotten.
    // Return the minimum number of minutes that must elapse until no cell has a fresh orange. If this is impossible, return -1.
    // Example 1:
    // Input: grid = [[2,1,1],[1,1,0],[0,1,1]]
    // Output: 4
    // Example 2:
    // Input: grid = [[2,1,1],[0,1,1],[1,0,1]]
    // Output: -1
    // Explanation: The orange in the bottom left corner (row 2, column 0) is never rotten, because rotting only happens 4-directionally.
    //     Example 3:
    // Input: grid = [[0,2]]
    // Output: 0
    // Explanation: Since there are already no fresh oranges at minute 0, the answer is just 0.
    //     Constraints:
    // m == grid.length
    // n == grid[i].length
    // 1 <= m, n <= 10
    // grid[i][j] is 0, 1, or 2.
    public int OrangesRotting(int[][] grid)
    {
        var minutes = 0;
        var rows = grid.Length;
        var cols = grid[0].Length;
        var queue = new Queue<(int r, int c)>();
        var fresh = 0;
        
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == 2)
                    queue.Enqueue((r, c));

                if (grid[r][c] == 1)
                    fresh++;
            }
        }

        if (fresh == 0)
            return 0;

        int[][] directions =
        {
            new[] {-1,0},
            new[] {1,0},
            new[] {0,-1},
            new[] {0,1}
        };

        while (queue.Count > 0 && fresh > 0)
        {
            int levelSize = queue.Count;

            for (int i = 0; i < levelSize; i++)
            {
                var (r, c) = queue.Dequeue();

                foreach (var d in directions)
                {
                    int nr = r + d[0];
                    int nc = c + d[1];

                    if (nr < 0 || nr >= rows ||
                        nc < 0 || nc >= cols)
                        continue;

                    if (grid[nr][nc] != 1)
                        continue;

                    grid[nr][nc] = 2;

                    fresh--;

                    queue.Enqueue((nr, nc));
                }
            }

            minutes++;
        }

        return fresh == 0
            ? minutes
            : -1;
    }

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