public class Solution {
    public int MaxArea(int[] heights) {
        var left = 0;
        var right = heights.Length - 1;
        var maxVolume = 0;

        while (left < right) {
            var currentVolune = (right - left) * Math.Min(heights[left], heights[right]);
            maxVolume = Math.Max(maxVolume, currentVolune);

            if (heights[left] > heights[right]) {
                right--;
            }
            else if (heights[left] < heights[right]) {
                left++;
            }
            else {
                right--;
            }
        }

        return maxVolume;
    }
}
