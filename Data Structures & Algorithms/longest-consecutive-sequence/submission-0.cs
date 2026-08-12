public class Solution {
    public int LongestConsecutive(int[] nums) {
        var map = new HashSet<int>(nums);
        var maxLength = 0;

        foreach (var num in map) {
            if (map.Contains(num - 1)) {
                // If nums contains lower num that current numver isn't start of sequence.
                continue;
            }

            var currentNum = num;
            var currentLength = 1;

            // Increase number untill we do.
            while (map.Contains(++currentNum)){
                currentLength++;
            }

            maxLength = Math.Max(maxLength, currentLength);
        }

        return maxLength;
    }
}
