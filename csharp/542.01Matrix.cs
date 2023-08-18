public class Solution {
    public int[][] UpdateMatrix(int[][] mat) 
    {
        int[][] result = mat.Select(s => s.ToArray()).ToArray();
        var queue = new List<(int dist, int row, int column)>();

        for (int i = 0; i < result.Length; i++)
        {
            for (int j = 0; j < result[i].Length; j++)
            {
                if (mat[i][j] == 0)
                {
                    result[i][j] = 0;
                    queue.Add((0, i, j));
                }
            }
        }

        while (queue.Count > 0)
        {
            var qel = queue[0];
            queue.RemoveAt(0);
            int d = qel.dist;
            int r = qel.row;
            int c = qel.column;
            
            int newCol = c + 1;
            if (newCol < mat[r].Length && mat[r][newCol] == 1)
            {
                result[r][newCol] = d + 1;
                queue.Add((d + 1, r, newCol));
                mat[r][newCol] = 0;
            }

            newCol = c - 1;
            if (newCol >= 0 && mat[r][newCol] == 1)
            {
                result[r][newCol] = d + 1;
                queue.Add((d + 1, r, newCol));
                mat[r][newCol] = 0;
            }

            int newRow = r + 1;
            if (newRow < mat.Length && mat[newRow][c] == 1)
            {
                result[newRow][c] = d + 1;
                queue.Add((d + 1, newRow, c));
                mat[newRow][c] = 0;
            }

            newRow = r - 1;
            if (newRow >= 0 && mat[newRow][c] == 1)
            {
                result[newRow][c] = d + 1;
                queue.Add((d + 1, newRow, c));
                mat[newRow][c] = 0;                  
            }
        }

        return result;
    }
}