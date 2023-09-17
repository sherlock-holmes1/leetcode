import java.util.HashSet;

class Solution {
    public boolean isValidSudoku(char[][] board) {
        int columns = board[0].length;
        HashSet<Character> rowSet;
        int numElementsInRow;
        for (char[] value : board) {
            rowSet = new HashSet<>();
            numElementsInRow = 0;
            for (int j = 0; j < columns; j++) {
                if (value[j] != '.') {
                    numElementsInRow += 1;
                    rowSet.add(value[j]);
                }
            }
            if (rowSet.size() != numElementsInRow) {
                return false;
            }
        }

        HashSet<Character> colSet;
        int numElementsInCol;
        for (int j = 0; j < columns; j++) {
            colSet = new HashSet<>();
            numElementsInCol = 0;
            for (char[] chars : board) {
                if (chars[j] != '.') {
                    numElementsInCol += 1;
                    colSet.add(chars[j]);
                }
            }
            if (colSet.size() != numElementsInCol) {
                return false;
            }
        }
        if (isValid3x3(board, 0, 3, 0, 3)) return false;
        if (isValid3x3(board, 0, 3, 3, 6)) return false;
        if (isValid3x3(board, 0, 3, 6, 9)) return false;

        if (isValid3x3(board, 3, 6, 0, 3)) return false;
        if (isValid3x3(board, 3, 6, 3, 6)) return false;
        if (isValid3x3(board, 3, 6, 6, 9)) return false;

        if (isValid3x3(board, 6, 9, 0, 3)) return false;
        if (isValid3x3(board, 6, 9, 3, 6)) return false;
        if (isValid3x3(board, 6, 9, 6, 9)) return false;

        return true;
    }
    private static boolean isValid3x3(char[][] board, int startY, int endY, int startX, int endX) {
        HashSet<Character> set3x3 = new HashSet<>();
        int numElements3x3 = 0;
        for (int i = startY; i < endY; i++)
        {
            for (int j = startX; j < endX; j++)
            {
                if (board[i][j] != '.')
                {
                    numElements3x3 += 1;
                    set3x3.add(board[i][j]);
                }
            }
        }
        if (set3x3.size() != numElements3x3)
        {
            return true;
        }
        return false;
    }
}