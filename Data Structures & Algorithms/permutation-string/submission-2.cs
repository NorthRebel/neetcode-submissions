public class Solution {
    private const int AlphabetLength = 26;
    public bool CheckInclusion(string s1, string s2) {
        if (s1.Length > s2.Length) {
            return false;
        }

        var target = new int[AlphabetLength];
        var window = new int[AlphabetLength];
        var matches = 0;

        for (var i = 0; i < s1.Length; i++) {
            target[s1[i]- 'a']++;
            window[s2[i]- 'a']++;
        }

        for (var i = 0; i < AlphabetLength; i++) {
            if (window[i] == target[i]) {
                matches++;
            }
        }

        if (matches == AlphabetLength) {
            return true;
        }

        for (var right = s1.Length; right < s2.Length; right++){
            var left = right - s1.Length;

            var leftChar = s2[left] - 'a';
            var rightChar = s2[right] - 'a';

            if (window[leftChar] == target[leftChar]) {
                matches--;
            }

            window[leftChar]--;

            if (window[leftChar] == target[leftChar]) {
                matches++;
            }

            if (window[rightChar] == target[rightChar]) {
                matches--;
            }

            window[rightChar]++;

            if (window[rightChar] == target[rightChar]) {
                matches++;
            }

            if (matches == AlphabetLength) {
                return true;
            }
        }

        return false;
    }
}
