using System.Collections.Generic;
using System.Linq.Expressions;

public class Solution542_01 {
    int initRow;
    int initCol;
    public int[][] UpdateMatrix(int[][] mat) 
    {
        int[][] result = mat.Select(s => s.ToArray()).ToArray();
        for (int i = 0; i < result.Length; i++)
        {
            for (int j = 0; j < result[i].Length; j++)
            {
                result[i][j] = -1;
            }
        }

        for (int row = 0; row < mat.Length; row++)
        {
            var queue = new List<(int el, int dist, int row, int column)>();

            for (int column = 0; column < mat[row].Length; column++)
            {
                var matElem = mat[row][column];
                if (matElem == 0)
                {
                    result[row][column] = 0;
                    continue;
                }

                queue.Add((matElem, 0, row, column));
                this.initRow = row;
                this.initCol = column;

                while (queue.Count > 0)
                {
                    var qel = queue[0];
                    queue.RemoveAt(0);
                    int d = qel.dist;
                    int r = qel.row;
                    int c = qel.column;

                    if (d > result[initRow][initCol] && result[initRow][initCol] != -1)
                    {
                        queue.Clear();
                        break;
                    }
                    
                    int newCol = c + 1;
                    if ((newCol, r) != (initCol, initRow) && newCol < mat[row].Length)
                    {
                        if (CheckIfElem0(mat, result, queue, qel, newCol, r))
                            continue;
                    }

                    newCol = c - 1;
                    if ((newCol, r) != (initCol, initRow) && newCol >= 0)
                    {
                        if (CheckIfElem0(mat, result, queue, qel, newCol, r))
                           continue;
                    }

                    int newRow = r + 1;
                    if ((newCol, r) != (initCol, initRow) && newRow < mat.Length)
                    {
                        if (CheckIfElem0(mat, result, queue, qel, c, newRow))
                            continue;
                    }

                    newRow = r - 1;
                    if ((c, newRow) != (initCol, initRow) && newRow >= 0)
                    {
                        if(CheckIfElem0(mat, result, queue, qel, c, newRow))
                            continue;       
                    }
                }
            }
        }

        return result;
    }

    private bool CheckIfElem0(int[][] mat, int[][] result, List<(int el, int dist, int row, int column)> queue, (int el, int dist, int row, int column) qel, int ccol, int rrow)
    {
        if (mat[rrow][ccol] == 0)
        {
            UpdateDist(result, qel.dist);
            return true;
        }
        else
        {
            queue.Add((qel.el, qel.dist + 1, rrow, ccol));
            return false;
        }
    }

    private void UpdateDist(int[][] result, int dist)
    {
        if (result[this.initRow][this.initCol] == -1)
        {
            result[initRow][initCol] = dist + 1;
            return;
        }

        if (result[initRow][initCol] > dist + 1)
            result[initRow][initCol] = dist + 1;
    }
}