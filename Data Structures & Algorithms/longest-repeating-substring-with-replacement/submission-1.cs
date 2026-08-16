public class Solution {
    public int CharacterReplacement(string s, int k) {
        int left = 0, right = 0;
        var charCount = new Dictionary<char, int>();
        var maxLength = 0;
        var maxFrequency = 0;

        for (; right < s.Length; right++) {
            var currentChar = s[right];

            if (!charCount.TryAdd(currentChar, 1)) {
                charCount[currentChar]++;
            }

            maxFrequency = Math.Max(maxFrequency, charCount[currentChar]);

            while (((right - left) + 1) - maxFrequency > k) {
                charCount[s[left]]--;
                left++;
            }

            var windowLength = (right - left) + 1;
            maxLength = Math.Max(maxLength, windowLength);
        }

        return maxLength;
    }
}
