public class Solution {
    private char[][] grid = new char[][] { Array.Empty<char>() };
    public int NumIslands(char[][] grid) 
    {
        this.grid = grid;
        var result = 0;
        var queue = new List<(int row, int column)>();
        
        for (int i = 0; i < grid.Length; i++) 
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == '0')
                {
                    queue.Add((i, j)); 
                }
            }
        }

        if (queue.Count == 0)
        {
            return 1;
        }
        
        while (queue.Count > 0) 
        {
            var el = queue[0];
            queue.RemoveAt(0);

            var col = el.column;
            var row = el.row;
            
            int[] steps = new int[] {1, -1};

            foreach (int step in steps)
            {
                if (IfOneForCol(col, row, step))
                {
                    result++;
                    this.grid[row][col + step] = '0';

                    var island_queue = new List<(int row, int col)>
                    {
                        (row, col + step),
                    };

                    this.GoForOnes(island_queue);
                }

                if (IfOneForRow(col, row, step))
                {
                    result++;
                    grid[row + step][col] = '0';

                    var island_queue = new List<(int row, int col)>
                    {
                        (row + step, col),
                    };

                    this.GoForOnes(island_queue);
                }
            }
        }

        return result;
    }

    private void GoForOnes(List<(int row, int col)> island_queue)
    {
        int[] steps = new int[] {1, -1};

        while (island_queue.Count > 0)
        {
            var (row, col) = island_queue[0];
            island_queue.RemoveAt(0);

            var c = col;
            var r = row;

            foreach (int step1 in steps)
            {
                if (IfOneForCol(c, r, step1))
                {
                    grid[r][c + step1] = '0';
                    island_queue.Add((r, c + step1));
                }
                if (IfOneForRow(c, r, step1))
                {
                    grid[r + step1][c] = '0';
                    island_queue.Add((r + step1, c));
                }
            }
        }
    }

    private bool IfOneForRow(int col, int row, int step)
    {
        return 0 <= row + step && row + step < grid.Length && grid[row + step][col] == '1';
    }

    private bool IfOneForCol(int col, int row, int step)
    {
        return 0 <= col + step && col + step < grid[row].Length && grid[row][col + step] == '1';
    }
}