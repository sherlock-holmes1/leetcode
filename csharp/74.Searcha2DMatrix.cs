public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int i;
        for (i = 0; i < matrix.Length; i++)
        {
            if (matrix[i][0] <= target && target <= matrix[i][^1])
                break;
        }

        if (i == matrix.Length)
        {   
            return false;
        }

        if (matrix[i][0] == target || target == matrix[i][^1])
        {
            return true;
        }

        int low = matrix[i][0];
        int low_pos = 0;
        int high = matrix[i][^1];
        int high_pos = matrix[i].Length - 1;
        int pos; 

        while (low < target && target < high && (high_pos - low_pos) > 1)
        {
            pos = (low_pos + high_pos) / 2;

            if ((low_pos + high_pos) % 2 > 0)
            {
                pos++;
            }

            if (matrix[i][pos] == target)
                return true;

            else if (matrix[i][pos] > target)
            {
                high_pos = pos;
                high = matrix[i][pos];
            }
            else if (matrix[i][pos] < target)
            {
                low_pos = pos;
                low = matrix[i][pos];
            }
        }

        return false;

    }
}