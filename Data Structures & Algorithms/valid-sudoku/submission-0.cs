public class Solution {
    private const char EmptyField = '.';
    private const int Size = 9;
    private const int BoxSize = 3;

    public bool IsValidSudoku(char[][] board) {
        var rows = new HashSet<char>[Size];
        var cols = new HashSet<char>[Size];
        var boxes = new HashSet<char>[Size];

        for (var i = 0; i < Size; i++) {
            rows[i] = new();
            cols[i] = new();
            boxes[i] = new();
        }

        for (var row = 0; row < Size; row++) {
            for (var col = 0; col < Size; col++) {
                var field = board[row][col];

                if (field == EmptyField) {
                    continue;
                }

                // (row / BoxSize) - index of row group
                // (col / BoxSize) - index of col group
                var boxIndex = (row / BoxSize) * BoxSize + (col / BoxSize);

                if (!rows[row].Add(field) ||
                    !cols[col].Add(field) ||
                     !boxes[boxIndex].Add(field)) {
                        return false;
                     }
            }
        }

        return true;
    }
}
