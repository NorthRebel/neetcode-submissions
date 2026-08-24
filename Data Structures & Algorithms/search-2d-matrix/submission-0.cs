public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        var totalSize = matrix.Length * matrix[0].Length;
        var left = 0;
        var right = totalSize - 1;
        var rowSize = matrix[0].Length;

        while (left <= right) {
            var middle = left + (right - left) / 2;
            var row = middle / rowSize;
            var col = middle % rowSize;

            var cellValue = matrix[row][col];

            if (cellValue < target)
            {
                left = middle + 1;
            }
            else if (cellValue > target)
            {
                right = middle - 1;
            }
            else
            {
                return true;
            }
        }

        return false;
    }
}
