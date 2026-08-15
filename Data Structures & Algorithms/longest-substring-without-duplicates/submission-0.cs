public class Solution {
    public int LengthOfLongestSubstring(string s) {
        var left = 0;
        var maxLength = 0;
        var lastIdexes = new Dictionary<char, int>();

        for (var right = 0; right < s.Length; right++) {
            var currentChar = s[right];

            if (!lastIdexes.TryAdd(currentChar, right)) {
                left = Math.Max(left, lastIdexes[currentChar] + 1);
                lastIdexes[currentChar] = right;
            }

            var windowLength = right - left + 1;
            maxLength = Math.Max(maxLength, windowLength);
        }

        return maxLength;
    }
}
